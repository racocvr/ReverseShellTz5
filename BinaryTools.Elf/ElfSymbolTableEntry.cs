namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF symbol table entry.
    /// </summary>
    public abstract class ElfSymbolTableEntry
    {
        /// <summary>
        /// Gets the name of the symbol.
        /// </summary>
        public string Name
        {
            get; internal set;
        }

        /// <summary>
        /// Gets or sets an index into the object file's symbol string table, which holds the character representations of the symbol names.
        /// </summary>
        public uint NameIndex
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the value of the associated symbol.
        /// </summary>
        public ulong Value
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the size associated with the symbol. For example, a data object's size is the number of bytes contained in the object.
        /// </summary>
        public ulong Size
        {
            get; internal set;
        }

        /// <summary>
        /// Gets or sets the symbol's binding.
        /// </summary>
        public ElfSymbolBinding Binding
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the symbol's type.
        /// </summary>
        public ElfSymbolType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the symbol's visibility.
        /// </summary>
        public ElfSymbolVisibility Visibility
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the relevant section header table index for which this symbol entry is defined.
        /// </summary>
        public ushort ShIndex
        {
            get; protected set;
        }
    }
}
