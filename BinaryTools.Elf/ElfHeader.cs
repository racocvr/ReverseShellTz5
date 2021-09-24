namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF header which contains metadata about the rest of the ELF file.
    /// </summary>
    public abstract class ElfHeader
    {
        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of the 1st ELF magic number.
        /// </summary>
        public const uint EI_MAG0 = 0;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of the 2nd ELF magic number.
        /// </summary>
        public const uint EI_MAG1 = 1;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of the 3rd ELF magic number.
        /// </summary>
        public const uint EI_MAG2 = 2;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of the 4th ELF magic number.
        /// </summary>
        public const uint EI_MAG3 = 3;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of class byte representing the bitness of this ELF file.
        /// </summary>
        public const uint EI_CLASS = 4;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of data byte representing the endianness of this ELF file.
        /// </summary>
        public const uint EI_DATA = 5;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of version byte representing version this ELF file.
        /// </summary>
        public const uint EI_VERSION = 6;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of OS ABI byte.
        /// </summary>
        public const uint EI_OSABI = 7;

        /// <summary>
        /// Gets the index within the <c>e_ident</c> structure of OS ABI version byte.
        /// </summary>
        public const uint EI_OSABIV = 8;

        /// <summary>
        /// Gets size in number of bytes of the <c>e_ident</c> structure.
        /// </summary>
        public const uint EI_NIDENT = 16;

        /// <summary>
        /// Gets the value of the 1st ELF magic number.
        /// </summary>
        public const byte ELFMAG0 = 0x7F;

        /// <summary>
        /// Gets the value of the 2nd ELF magic number.
        /// </summary>
        public const byte ELFMAG1 = 0x45;

        /// <summary>
        /// Gets the value of the 3rd ELF magic number.
        /// </summary>
        public const byte ELFMAG2 = 0x4C;

        /// <summary>
        /// Gets the value of the 4th ELF magic number.
        /// </summary>
        public const byte ELFMAG3 = 0x46;

        /// <summary>
        /// Gets the value of an invalid ELF file bitness.
        /// </summary>
        public const byte ELFCLASSNONE = 0x00;

        /// <summary>
        /// Gets the value of an ELF file with 32-bit objects.
        /// </summary>
        public const byte ELFCLASS32 = 0x01;

        /// <summary>
        /// Gets the value of an ELF file with 64-bit objects.
        /// </summary>
        public const byte ELFCLASS64 = 0x02;

        /// <summary>
        /// Gets the value of an invalid ELF endianness.
        /// </summary>
        public const byte ELFDATANONE = 0x00;

        /// <summary>
        /// Gets the value of an little-endian (least significant byte first) ELF endianness.
        /// </summary>
        public const byte ELFDATA2LSB = 0x01;

        /// <summary>
        /// Gets the value of an big-endian (most significant byte first) ELF endianness.
        /// </summary>
        public const byte ELFDATA2MSB = 0x02;

        /// <summary>
        /// Gets or sets the size of the ELF header.
        /// </summary>
        public ushort Size
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file bitness.
        /// </summary>
        public ElfClass Class
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file endianness.
        /// </summary>
        public ElfData Data
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file Operating System (OS) Application Binary Interface (ABI).
        /// </summary>
        public ElfOSABI OSABI
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file Operating System (OS) Application Binary Interface (ABI) version.
        /// </summary>
        public byte OSABIVersion
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets interpretation of this field depends on the target architecture.
        /// </summary>
        public uint Flags
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file type.
        /// </summary>
        public ElfType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file version.
        /// </summary>
        public uint Version
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the ELF file Instruction Set Architecture (ISA).
        /// </summary>
        public ElfMachine Machine
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets memory address of the entry point from where the process starts executing.
        /// </summary>
        public ulong EntryOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the offset in number of bytes to the start of the section header table.
        /// </summary>
        public ulong SectionHeaderOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the size in number of bytes of the section header table.
        /// </summary>
        public ushort SectionHeaderSize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the number of sections in the section header table.
        /// </summary>
        public ushort SectionHeaderEntryCount
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the offset in number of bytes to the start of the program header table.
        /// </summary>
        public ulong ProgramHeaderOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the size in number of bytes of the program header table.
        /// </summary>
        public ushort ProgramHeaderSize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the number of segments in the program header table.
        /// </summary>
        public ushort ProgramHeaderEntryCount
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the index in the section header table that contains the section names.
        /// </summary>
        public ushort StringSectionIndex
        {
            get; protected set;
        }
    }
}
