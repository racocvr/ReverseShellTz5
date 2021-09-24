namespace BinaryTools.Elf
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents an ELF segment.
    /// </summary>
    public abstract class ElfSegment
    {
        /// <summary>
        /// Gets the type value of a segment that is unused.
        /// </summary>
        public const uint PT_NULL = 0x00000000;

        /// <summary>
        /// Gets the type value of a segment representing a loadable segment.
        /// </summary>
        public const uint PT_LOAD = 0x00000001;

        /// <summary>
        /// Gets the type value of a segment representing dynamic linking information.
        /// </summary>
        public const uint PT_DYNAMIC = 0x00000002;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of a null-terminated path name to invoke as an interpreter.
        /// </summary>
        public const uint PT_INTERP = 0x00000003;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of auxiliary information.
        /// </summary>
        public const uint PT_NOTE = 0x00000004;

        /// <summary>
        /// Gets the type value of a segment with unspecified semantics.
        /// </summary>
        public const uint PT_SHLIB = 0x00000005;

        /// <summary>
        /// Gets the type value of a segment representing the lIBM.OMR.CoreAnalyzer.ion and size of the program header table itself.
        /// </summary>
        public const uint PT_PHDR = 0x00000006;

        /// <summary>
        /// Gets the type value representing the lower bound of a segment holding processor specific semantics.
        /// </summary>
        public const uint PT_LOPROC = 0x70000000;

        /// <summary>
        /// Gets the type value representing the upper bound of a segment holding processor specific semantics.
        /// </summary>
        public const uint PT_HIPROC = 0x7FFFFFFF;

        /// <summary>
        /// Gets the flag value representing an executable segment.
        /// </summary>
        public const uint PF_X = 0x00000001;

        /// <summary>
        /// Gets the flag value representing a writable segment.
        /// </summary>
        public const uint PF_W = 0x00000002;

        /// <summary>
        /// Gets the flag value representing a readable segment.
        /// </summary>
        public const uint PF_R = 0x00000004;

        /// <summary>
        /// Gets or sets the size in number of bytes of the segment on disk.
        /// </summary>
        public ulong FileSize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the offset from the beginning of the ELF file the first byte in this segment.
        /// </summary>
        public ulong Offset
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the size in number of bytes of this segment in memory.
        /// </summary>
        public ulong MemorySize
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the virtual address of this segment.
        /// </summary>
        public ulong VirtualAddress
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the physical address of this segment.
        /// </summary>
        public ulong PhysicalAddress
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the address alignment of this segment.
        /// </summary>
        public ulong Alignment
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the type of this segment.
        /// </summary>
        public ElfSegmentType Type
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the flags of this segment.
        /// </summary>
        public ElfSegmentFlags Flags
        {
            get; protected set;
        }

        /// <summary>
        /// Gets a list of sections mapped to this segment.
        /// </summary>
        public IReadOnlyList<ElfSection> Sections
        {
            get; internal set;
        }
    }
}
