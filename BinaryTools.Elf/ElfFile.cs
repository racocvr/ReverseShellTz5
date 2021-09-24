namespace BinaryTools.Elf
{
    using System;
    using System.IO;
    using System.Text;
    using BinaryTools.Elf.Io;

    /// <summary>
    /// Represents an Executable Linkable Format (ELF) file.
    /// </summary>
    public sealed class ElfFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfFile"/> class.
        /// </summary>
        ///
        /// <param name="header">
        /// The ELF file header.
        /// </param>
        ///
        /// <param name="segments">
        /// The program header table.
        /// </param>
        ///
        /// <param name="sections">
        /// The section header table.
        /// </param>
        internal ElfFile(ElfHeader header, ElfProgramHeaderTable segments, ElfSectionHeaderTable sections)
        {
            Header = header;

            Segments = segments;
            Sections = sections;
        }

        /// <summary>
        /// Gets the ELF header which contains metadata about segments and sections of the ELF file.
        /// </summary>
        public ElfHeader Header
        {
            get;
        }

        /// <summary>
        /// Gets the program header table containing a list of segments.
        /// </summary>
        public ElfProgramHeaderTable Segments
        {
            get;
        }

        /// <summary>
        /// Gets the section header table containing a list of sections.
        /// </summary>
        public ElfSectionHeaderTable Sections
        {
            get;
        }

        /// <summary>
        /// Reads an ELF file from a binary reader.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to parse the ELF file.
        /// </param>
        ///
        /// <returns>
        /// The ELF file parsed from the binary reader.
        /// </returns>
        ///
        /// <exception cref="FileFormatException">
        /// <paramref name="reader"/> base stream does not represent a valid ELF file.
        /// </exception>
        public static ElfFile ReadElfFile(BinaryReader reader)
        {
            try
            {
                long savedPosition = reader.BaseStream.Position;

                byte magic0 = reader.ReadByte();
                byte magic1 = reader.ReadByte();
                byte magic2 = reader.ReadByte();
                byte magic3 = reader.ReadByte();

                if (magic0 != ElfHeader.ELFMAG0 || magic1 != ElfHeader.ELFMAG1 || magic2 != ElfHeader.ELFMAG2 || magic3 != ElfHeader.ELFMAG3)
                {
                    throw new FileFormatException($"Invalid ELF magic bytes: 0x{magic0,0:X2} 0x{magic1,0:X2} 0x{magic2,0:X2} 0x{magic3,0:X2}");
                }

                byte @class = reader.ReadByte();

                if (@class != ElfHeader.ELFCLASS32 && @class != ElfHeader.ELFCLASS64)
                {
                    throw new FileFormatException($"Invalid ELF class: 0x{@class,0:X2}");
                }

                byte endianness = reader.ReadByte();

                if (endianness != ElfHeader.ELFDATA2LSB && endianness != ElfHeader.ELFDATA2MSB)
                {
                    throw new FileFormatException($"Invalid ELF endianness: 0x{endianness,0:X2}");
                }

                // Re-materialize the reader with the parsed endianness
                reader = new EndianBinaryReader(reader.BaseStream, endianness == ElfHeader.ELFDATA2MSB ? Endianness.BigEndian : Endianness.LittleEndian, Encoding.UTF8, true);

                ElfHeader header;

                switch (@class)
                {
                    case ElfHeader.ELFCLASS32:
                    {
                        header = new Bit32.ElfHeader(reader, savedPosition);
                        break;
                    }

                    case ElfHeader.ELFCLASS64:
                    {
                        header = new Bit64.ElfHeader(reader, savedPosition);
                        break;
                    }

                    default:
                    {
                        throw new InvalidOperationException("Unreachable case reached");
                    }
                }

                var sections = new ElfSectionHeaderTable(reader, header);
                var segments = new ElfProgramHeaderTable(reader, header, sections);

                reader.BaseStream.Position = savedPosition;

                return new ElfFile(header, segments, sections);
            }
            catch (InaccessibleAddressException exception)
            {
                throw new FileFormatException(exception.Message, exception);
            }
        }
    }
}
