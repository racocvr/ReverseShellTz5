namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF relocation entry.
    /// </summary>
    public abstract class ElfRelocationEntry
    {
        /// <summary>
        /// Gets or sets the location at which to apply the relocation action. For a relocatable file, the value is the byte offset from the beginning of the section to the storage unit affected by the relocation. For an executable file or a shared object, the value is the virtual address of the storage unit affected by the relocation.
        /// </summary>
        public ulong Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the symbol table index with respect to which the relocation must be made, and the type of relocation to apply.
        /// </summary>
        public ulong Info
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the processor specific relocation type. See <see cref="ElfRelocationSection"/> for more details.
        /// </summary>
        public uint Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets a constant addend used to compute the value to be stored into the relocatable field, if it exists.
        /// </summary>
        public ulong Addend
        {
            get; protected set;
        }

        /// <summary>
        /// Gets name of the symbol to relocate.
        /// </summary>
        public string Symbol
        {
            get; internal set;
        }

        /// <summary>
        /// Gets or sets symbol table index with respect to which the relocation must be made.
        /// </summary>
        public int SymbolIndex
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the value from the symbol table corresponding to this relocation symbol.
        /// </summary>
        public ulong SymbolValue
        {
            get; internal set;
        }
    }
}
