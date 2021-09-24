namespace BinaryTools.Elf
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ELF relocation section.
    /// </summary>
    public abstract class ElfRelocationSection : ElfSection, IReadOnlyList<ElfRelocationEntry>
    {
        /// <summary>
        /// No relocation needed.
        /// </summary>
        public const uint R_X86_64_NONE = 0;

        /// <summary>
        /// Direct 64-bit relocation.
        /// </summary>
        public const uint R_X86_64_64 = 1;

        /// <summary>
        /// Program counter (PC) relative 32-bit signed relocation.
        /// </summary>
        public const uint R_X86_64_PC32 = 2;

        /// <summary>
        /// 32-bit GOT entry.
        /// </summary>
        public const uint R_X86_64_GOT32 = 3;

        /// <summary>
        /// 32-bit PLT address.
        /// </summary>
        public const uint R_X86_64_PLT32 = 4;

        /// <summary>
        /// Copy symbol at runtime.
        /// </summary>
        public const uint R_X86_64_COPY = 5;

        /// <summary>
        /// Create GOT entry.
        /// </summary>
        public const uint R_X86_64_GLOB_DAT = 6;

        /// <summary>
        /// Create PLT entry.
        /// </summary>
        public const uint R_X86_64_JUMP_SLOT = 7;

        /// <summary>
        /// Adjust by program base.
        /// </summary>
        public const uint R_X86_64_RELATIVE = 8;

        /// <summary>
        /// 32-bit signed PC relative offset to GOT.
        /// </summary>
        public const uint R_X86_64_GOTPCREL = 9;

        /// <summary>
        /// Direct 32-bit zero extended relocation.
        /// </summary>
        public const uint R_X86_64_32 = 10;

        /// <summary>
        /// Direct 32-bit sign extended relocation.
        /// </summary>
        public const uint R_X86_64_32S = 11;

        /// <summary>
        /// Direct 16-bit zero extended relocation.
        /// </summary>
        public const uint R_X86_64_16 = 12;

        /// <summary>
        /// 16-bit signed extended PC relative relocation.
        /// </summary>
        public const uint R_X86_64_PC16 = 13;

        /// <summary>
        /// Direct 8-bit sign extended relocation.
        /// </summary>
        public const uint R_X86_64_8 = 14;

        /// <summary>
        /// 8-bit sign extended PC relative relocation.
        /// </summary>
        public const uint R_X86_64_PC8 = 15;

        /// <summary>
        /// Place relative 64-bit signed relocation.
        /// </summary>
        public const uint R_X86_64_PC64 = 24;

        /// <summary>
        /// Gets the number of relocation entries in this section.
        /// </summary>
        public int Count => Entries.Count;

        /// <summary>
        /// Gets the list of relocation entries in this relocation section.
        /// </summary>
        protected List<ElfRelocationEntry> Entries
        {
            get;
        }

        = new List<ElfRelocationEntry>();

        /// <summary>
        /// Gets a relocation entry at an index.
        /// </summary>
        ///
        /// <param name="index">
        /// The index of the relocation entry.
        /// </param>
        ///
        /// <returns>
        /// The relocation entry at the given index.
        /// </returns>
        public ElfRelocationEntry this[int index] => Entries[index];

        /// <summary>
        /// Returns an enumerator that iterates through the relocation section entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the relocation section entries.
        /// </returns>
        public IEnumerator<ElfRelocationEntry> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the relocation section entries.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the relocation section entries.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
