namespace BinaryTools.Elf
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ELF string table.
    /// </summary>
    public abstract class ElfStringTable : ElfSection, IReadOnlyList<ElfStringTableEntry>
    {
        /// <summary>
        /// Gets the number of strings in this section.
        /// </summary>
        public int Count => Entries.Count;

        /// <summary>
        /// Gets the list of string entries (index and value) in this string table.
        /// </summary>
        protected List<ElfStringTableEntry> Entries
        {
            get;
        }

        = new List<ElfStringTableEntry>();

        /// <summary>
        /// Gets a string entry at an index.
        /// </summary>
        ///
        /// <param name="index">
        /// The index of the string entry.
        /// </param>
        ///
        /// <returns>
        /// The string entry at the given index.
        /// </returns>
        public ElfStringTableEntry this[int index] => Entries[index];

        /// <summary>
        /// Returns an enumerator that iterates through the string table entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the string table entries.
        /// </returns>
        public IEnumerator<ElfStringTableEntry> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the string table entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the string table entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
