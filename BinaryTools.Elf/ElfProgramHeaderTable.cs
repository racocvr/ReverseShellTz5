namespace BinaryTools.Elf
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Represents an ELF program header table which describes a list of ELF segments.
    /// </summary>
    public sealed class ElfProgramHeaderTable : IReadOnlyList<ElfSegment>
    {
        /// <summary>
        /// Gets the list of ELF segments in this program header table.
        /// </summary>
        private readonly List<ElfSegment> segments = new List<ElfSegment>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ElfProgramHeaderTable"/> class by examining an ELF header.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to parse the ELF file.
        /// </param>
        ///
        /// <param name="header">
        /// The ELF header used to extract the metadata about this program header table.
        /// </param>
        ///
        /// <param name="sections">
        /// The list of sections which will be parsed to extract the sections corresponding to this segment.
        /// </param>
        internal ElfProgramHeaderTable(BinaryReader reader, ElfHeader header, ElfSectionHeaderTable sections)
        {
            // Initialize all segments
            for (var i = 0; i < header.ProgramHeaderEntryCount; i++)
            {
                ElfSegment segment;

                switch (header.Class)
                {
                    case ElfClass.Elf32:
                    {
                        segment = new Bit32.ElfSegment(reader, (long)(header.ProgramHeaderOffset + (ulong)(i * header.ProgramHeaderSize)));
                        break;
                    }

                    case ElfClass.Elf64:
                    {
                        segment = new Bit64.ElfSegment(reader, (long)(header.ProgramHeaderOffset + (ulong)(i * header.ProgramHeaderSize)));
                        break;
                    }

                    default:
                    {
                        throw new InvalidOperationException("Unreachable case reached");
                    }
                }

                segment.Sections = sections.Where(s => s.Address >= segment.VirtualAddress && s.Address < segment.VirtualAddress + segment.MemorySize).ToList().AsReadOnly();

                segments.Add(segment);
            }
        }

        /// <summary>
        /// Gets the number of ELF segments in this program header table.
        /// </summary>
        public int Count => segments.Count;

        /// <summary>
        /// Gets an ELF segment at an index.
        /// </summary>
        ///
        /// <param name="index">
        /// The index of the ELF segment.
        /// </param>
        ///
        /// <returns>
        /// The ELF segment at the given index.
        /// </returns>
        public ElfSegment this[int index] => segments[index];

        /// <summary>
        /// Returns an enumerator that iterates through the ELF segments.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF segments.
        /// </returns>
        public IEnumerator<ElfSegment> GetEnumerator()
        {
            return segments.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ELF segments.
        /// </summary>
        ///
        /// <returns>
        /// An enumerator that can be used to iterate through the ELF segments.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
