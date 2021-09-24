namespace BinaryTools.Elf
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ELF symbol table.
    /// </summary>
    public abstract class ElfSymbolTable : ElfSection, IReadOnlyList<ElfSymbolTableEntry>
    {
        /// <summary>
        /// Gets the number of symbol entries in this section.
        /// </summary>
        public int Count => Entries.Count;

        /// <summary>
        /// Gets the list of symbol entries in this symbol table.
        /// </summary>
        protected List<ElfSymbolTableEntry> Entries
        {
            get;
        }

        = new List<ElfSymbolTableEntry>();

        /// <summary>
        /// Gets a symbol entry at an index.
        /// </summary>
        ///
        /// <param name="index">
        /// The index of the symbol entry.
        /// </param>
        ///
        /// <returns>
        /// The symbol entry at the given index.
        /// </returns>
        public ElfSymbolTableEntry this[int index] => Entries[index];

        /// <summary>
        /// Returns an enumerator that iterates through the symbol table entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the symbol table entries.
        /// </returns>
        public IEnumerator<ElfSymbolTableEntry> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the symbol table entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the symbol table entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
