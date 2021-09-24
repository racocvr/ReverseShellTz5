namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the required architecture for an individual ELF file.
    /// </summary>
    public enum ElfMachine : ushort
    {
        /// <summary>
        /// No machine
        /// </summary>
        [Description("No machine")]
        None = 0,

        /// <summary>
        /// ATT WE 32100
        /// </summary>
        [Description("AT&T WE 32100")]
        M32 = 1,

        /// <summary>
        /// SPARC
        /// </summary>
        [Description("SPARC")]
        SPARC = 2,

        /// <summary>
        /// Intel 80386
        /// </summary>
        [Description("Intel 80386")]
        I386 = 3,

        /// <summary>
        /// Motorola 68000
        /// </summary>
        [Description("Motorola 68000")]
        M68K = 4,

        /// <summary>
        /// Motorola 88000
        /// </summary>
        [Description("Motorola 88000")]
        M88K = 5,

        /// <summary>
        /// Reserved for future use (was EM_486)
        /// </summary>
        [Description("Reserved for future use (was EM_486)")]
        Reserved6 = 6,

        /// <summary>
        /// Intel 80860
        /// </summary>
        [Description("Intel 80860")]
        I860 = 7,

        /// <summary>
        /// MIPS I Architecture
        /// </summary>
        [Description("MIPS I Architecture")]
        MIPS = 8,

        /// <summary>
        /// IBM System/370 Processor
        /// </summary>
        [Description("IBM System/370 Processor")]
        S370 = 9,

        /// <summary>
        /// MIPS RS3000 Little-endian
        /// </summary>
        [Description("MIPS RS3000 Little-endian")]
        MIPSRS3LE = 10,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved11 = 11,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved12 = 12,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved13 = 13,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved14 = 14,

        /// <summary>
        /// Hewlett-Packard PA-RISC
        /// </summary>
        [Description("Hewlett-Packard PA-RISC")]
        PARISC = 15,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved16 = 16,

        /// <summary>
        /// Fujitsu VPP500
        /// </summary>
        [Description("Fujitsu VPP500")]
        FujitsuVPP500 = 17,

        /// <summary>
        /// Enhanced instruction set SPARC
        /// </summary>
        [Description("Enhanced instruction set SPARC")]
        SPARC32Plus = 18,

        /// <summary>
        /// Intel 80960
        /// </summary>
        [Description("Intel 80960")]
        I960 = 19,

        /// <summary>
        /// PowerPC
        /// </summary>
        [Description("PowerPC")]
        PPC = 20,

        /// <summary>
        /// 64-bit PowerPC
        /// </summary>
        [Description("64-bit PowerPC")]
        PPC64 = 21,

        /// <summary>
        /// IBM System/390 Processor
        /// </summary>
        [Description("IBM System/390 Processor")]
        S390 = 22,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved23 = 23,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved24 = 24,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved25 = 25,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved26 = 26,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved27 = 27,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved28 = 28,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved29 = 29,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved30 = 30,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved31 = 31,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved32 = 32,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved33 = 33,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved34 = 34,

        /// <summary>
        /// Reserved for future use
        /// </summary>
        [Description("Reserved for future use")]
        Reserved35 = 35,

        /// <summary>
        /// NEC V800
        /// </summary>
        [Description("NEC V800")]
        V800 = 36,

        /// <summary>
        /// Fujitsu FR20
        /// </summary>
        [Description("Fujitsu FR20")]
        FR20 = 37,

        /// <summary>
        /// TRW RH-32
        /// </summary>
        [Description("TRW RH-32")]
        RG32 = 38,

        /// <summary>
        /// Motorola RCE
        /// </summary>
        [Description("Motorola RCE")]
        RCE = 38,

        /// <summary>
        /// Advanced RISC Machines ARM
        /// </summary>
        [Description("Advanced RISC Machines ARM")]
        ARM = 40,

        /// <summary>
        /// Digital Alpha
        /// </summary>
        [Description("Digital Alpha")]
        Alpha = 41,

        /// <summary>
        /// Hitachi SH
        /// </summary>
        [Description("Hitachi SH")]
        SH = 42,

        /// <summary>
        /// SPARC Version 9
        /// </summary>
        [Description("SPARC Version 9")]
        SPARCV9 = 43,

        /// <summary>
        /// Siemens TriCore embedded processor
        /// </summary>
        [Description("Siemens TriCore embedded processor")]
        TriCore = 44,

        /// <summary>
        /// Argonaut RISC Core, Argonaut Technologies Inc.
        /// </summary>
        [Description("Argonaut RISC Core, Argonaut Technologies Inc.")]
        ARC = 45,

        /// <summary>
        /// Hitachi H8/300
        /// </summary>
        [Description("Hitachi H8/300")]
        H8300 = 46,

        /// <summary>
        /// Hitachi H8/300H
        /// </summary>
        [Description("Hitachi H8/300H")]
        H8300H = 47,

        /// <summary>
        /// Hitachi H8S
        /// </summary>
        [Description("Hitachi H8S")]
        H8S = 48,

        /// <summary>
        /// Hitachi H8/500
        /// </summary>
        [Description("Hitachi H8/500")]
        H8500 = 49,

        /// <summary>
        /// Intel IA-64 processor architecture
        /// </summary>
        [Description("Intel IA-64 processor architecture")]
        IA64 = 50,

        /// <summary>
        /// Stanford MIPS-X
        /// </summary>
        [Description("Stanford MIPS-X")]
        MIPSX = 51,

        /// <summary>
        /// Motorola ColdFire
        /// </summary>
        [Description("Motorola ColdFire")]
        ColdFire = 52,

        /// <summary>
        /// Motorola M68HC12
        /// </summary>
        [Description("Motorola M68HC12")]
        M68HC12 = 53,

        /// <summary>
        /// Fujitsu MMA Multimedia Accelerator
        /// </summary>
        [Description("Fujitsu MMA Multimedia Accelerator")]
        MMA = 54,

        /// <summary>
        /// Siemens PCP
        /// </summary>
        [Description("Siemens PCP")]
        PCP = 55,

        /// <summary>
        /// Sony nCPU embedded RISC processor
        /// </summary>
        [Description("Sony nCPU embedded RISC processor")]
        NCPU = 56,

        /// <summary>
        /// Denso NDR1 microprocessor
        /// </summary>
        [Description("Denso NDR1 microprocessor")]
        NDR1 = 57,

        /// <summary>
        /// Motorola Star*Core processor
        /// </summary>
        [Description("Motorola Star*Core processor")]
        StarCore = 58,

        /// <summary>
        /// Toyota ME16 processor
        /// </summary>
        [Description("Toyota ME16 processor")]
        ME16 = 59,

        /// <summary>
        /// STMicroelectronics ST100 processor
        /// </summary>
        [Description("STMicroelectronics ST100 processor")]
        ST100 = 60,

        /// <summary>
        /// Advanced Logic Corp. TinyJ embedded processor family
        /// </summary>
        [Description("Advanced Logic Corp. TinyJ embedded processor family")]
        TINYJ = 61,

        /// <summary>
        /// AMD x86-64 architecture
        /// </summary>
        [Description("AMD x86-64 architecture")]
        X8664 = 62,

        /// <summary>
        /// Sony DSP Processor
        /// </summary>
        [Description("Sony DSP Processor")]
        PDSP = 63,

        /// <summary>
        /// Digital Equipment Corp. PDP-10
        /// </summary>
        [Description("Digital Equipment Corp. PDP-10")]
        PDP10 = 64,

        /// <summary>
        /// Digital Equipment Corp. PDP-11
        /// </summary>
        [Description("Digital Equipment Corp. PDP-11")]
        PDP11 = 10,

        /// <summary>
        /// Siemens FX66 microcontroller
        /// </summary>
        [Description("Siemens FX66 microcontroller")]
        FX66 = 66,

        /// <summary>
        /// STMicroelectronics ST9+ 8/16 bit microcontroller
        /// </summary>
        [Description("STMicroelectronics ST9+ 8/16 bit microcontroller")]
        ST9PLUS = 67,

        /// <summary>
        /// STMicroelectronics ST7 8-bit microcontroller
        /// </summary>
        [Description("STMicroelectronics ST7 8-bit microcontroller")]
        ST7 = 68,

        /// <summary>
        /// Motorola MC68HC16 Microcontroller
        /// </summary>
        [Description("Motorola MC68HC16 Microcontroller")]
        MC68HC16 = 69,

        /// <summary>
        /// Motorola MC68HC11 Microcontroller
        /// </summary>
        [Description("Motorola MC68HC11 Microcontroller")]
        MC68HC11 = 70,

        /// <summary>
        /// Motorola MC68HC08 Microcontroller
        /// </summary>
        [Description("Motorola MC68HC08 Microcontroller")]
        MC68HC08 = 71,

        /// <summary>
        /// Motorola MC68HC05 Microcontroller
        /// </summary>
        [Description("Motorola MC68HC05 Microcontroller")]
        MC68HC05 = 72,

        /// <summary>
        /// Silicon Graphics SVx
        /// </summary>
        [Description("Silicon Graphics SVx")]
        SVX = 73,

        /// <summary>
        /// STMicroelectronics ST19 8-bit microcontroller
        /// </summary>
        [Description("STMicroelectronics ST19 8-bit microcontroller")]
        ST19 = 74,

        /// <summary>
        /// Digital VAX
        /// </summary>
        [Description("Digital VAX")]
        VAX = 75,

        /// <summary>
        /// Axis Communications 32-bit embedded processor
        /// </summary>
        [Description("Axis Communications 32-bit embedded processor")]
        CRIS = 76,

        /// <summary>
        /// Infineon Technologies 32-bit embedded processor
        /// </summary>
        [Description("Infineon Technologies 32-bit embedded processor")]
        JAVELIN = 77,

        /// <summary>
        /// Element 14 64-bit DSP Processor
        /// </summary>
        [Description("Element 14 64-bit DSP Processor")]
        FIREPATH = 78,

        /// <summary>
        /// LSI Logic 16-bit DSP Processor
        /// </summary>
        [Description("LSI Logic 16-bit DSP Processor")]
        ZSP = 79,

        /// <summary>
        /// Donald Knuth's educational 64-bit processor
        /// </summary>
        [Description("Donald Knuth's educational 64-bit processor")]
        MMIX = 80,

        /// <summary>
        /// Harvard University machine-independent object files
        /// </summary>
        [Description("Harvard University machine-independent object files")]
        HUANY = 81,

        /// <summary>
        /// SiTera Prism
        /// </summary>
        [Description("SiTera Prism")]
        Prism = 82,

        /// <summary>
        /// Atmel AVR 8-bit microcontroller
        /// </summary>
        [Description("Atmel AVR 8-bit microcontroller")]
        AVR = 83,

        /// <summary>
        /// Fujitsu FR30
        /// </summary>
        [Description("Fujitsu FR30")]
        FR30 = 84,

        /// <summary>
        /// Mitsubishi D10V
        /// </summary>
        [Description("Mitsubishi D10V")]
        D10V = 85,

        /// <summary>
        /// Mitsubishi D30V
        /// </summary>
        [Description("Mitsubishi D30V")]
        D30V = 86,

        /// <summary>
        /// NEC v850
        /// </summary>
        [Description("NEC v850")]
        V850 = 87,

        /// <summary>
        /// Mitsubishi M32R
        /// </summary>
        [Description("Mitsubishi M32R")]
        M32R = 88,

        /// <summary>
        /// Matsushita MN10300
        /// </summary>
        [Description("Matsushita MN10300")]
        MN10300 = 89,

        /// <summary>
        /// Matsushita MN10200
        /// </summary>
        [Description("Matsushita MN10200")]
        MN10200 = 90,

        /// <summary>
        /// picoJava
        /// </summary>
        [Description("picoJava")]
        PJ = 91,

        /// <summary>
        /// OpenRISC 32-bit embedded processor
        /// </summary>
        [Description("OpenRISC 32-bit embedded processor")]
        OpenRISC = 92,

        /// <summary>
        /// ARC Cores Tangent-A5
        /// </summary>
        [Description("ARC Cores Tangent-A5")]
        ARCA5 = 93,

        /// <summary>
        /// Tensilica Xtensa Architecture
        /// </summary>
        [Description("Tensilica Xtensa Architecture")]
        Xtensa = 94,

        /// <summary>
        /// Alphamosaic VideoCore processor
        /// </summary>
        [Description("Alphamosaic VideoCore processor")]
        VideoCore = 95,

        /// <summary>
        /// Thompson Multimedia General Purpose Processor
        /// </summary>
        [Description("Thompson Multimedia General Purpose Processor")]
        TMMGPP = 96,

        /// <summary>
        /// National Semiconductor 32000 series
        /// </summary>
        [Description("National Semiconductor 32000 series")]
        NS32K = 97,

        /// <summary>
        /// Tenor Network TPC processor
        /// </summary>
        [Description("Tenor Network TPC processor")]
        TPC = 98,

        /// <summary>
        /// Trebia SNP 1000 processor
        /// </summary>
        [Description("Trebia SNP 1000 processor")]
        SNP1K = 99,

        /// <summary>
        /// STMicroelectronics (www.st.com) ST200 microcontroller
        /// </summary>
        [Description("STMicroelectronics (www.st.com) ST200 microcontroller")]
        ST200 = 100,
    }
}
