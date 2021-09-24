namespace BinaryTools.Elf
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ELF dynamic section.
    /// </summary>
    public abstract class ElfDynamicSection : ElfSection, IReadOnlyList<ElfDynamicEntry>
    {
        /// <summary>
        /// Gets the number of dynamic entries in this section.
        /// </summary>
        public int Count => Entries.Count;

        /// <summary>
        /// Gets the list of dynamic entries in this dynamic section.
        /// </summary>
        protected List<ElfDynamicEntry> Entries
        {
            get;
        }

        = new List<ElfDynamicEntry>();

        /// <summary>
        /// Gets a dynamic entry at an index.
        /// </summary>
        ///
        /// <param name="index">
        /// The index of the dynamic entry.
        /// </param>
        ///
        /// <returns>
        /// The dynamic entry at the given index.
        /// </returns>
        public ElfDynamicEntry this[int index] => Entries[index];

        /// <summary>
        /// Returns an enumerator that iterates through the dynamic section entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the dynamic section entries.
        /// </returns>
        public IEnumerator<ElfDynamicEntry> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the dynamic section entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the dynamic section entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
