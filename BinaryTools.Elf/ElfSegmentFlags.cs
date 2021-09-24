namespace BinaryTools.Elf
{
    using System;

    /// <summary>
    /// Enumerates the ELF section's contents and semantics.
    /// </summary>
    [Flags]
    public enum ElfSegmentFlags : uint
    {
        /// <summary>
        /// The segement is executable.
        /// </summary>
        Exec = 0x1,

        /// <summary>
        /// The segement is writeable.
        /// </summary>
        Write = 0x2,

        /// <summary>
        /// The segement is readable.
        /// </summary>
        Read = 0x4,
    }
}
