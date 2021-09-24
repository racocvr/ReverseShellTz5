namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF section.
    /// </summary>
    public abstract class ElfSection
    {
        /// <summary>
        /// Gets the name of this section.
        /// </summary>
        public string Name
        {
            get; internal set;
        }

        /// <summary>
        /// Gets or sets the offset in the string table of the name of this section.
        /// </summary>
        public uint NameOffset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the size in number of bytes of this section.
        /// </summary>
        public ulong Size
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the size of the fixed-sized entries of this section.
        /// </summary>
        public ulong EntrySize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the offset from the beginning of the ELF file the first byte in this section.
        /// </summary>
        public ulong Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the address of this section.
        /// </summary>
        public ulong Address
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the address alignment of this section.
        /// </summary>
        public ulong Alignment
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the type of this section.
        /// </summary>
        public ElfSectionType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the flags of this section.
        /// </summary>
        public ElfSectionFlags Flags
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets a section header table index link whose interpretation depends on the section type.
        /// </summary>
        public uint Link
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the extra information whose interpretation depends on the section type.
        /// </summary>
        public uint Info
        {
            get; protected set;
        }
    }
}
