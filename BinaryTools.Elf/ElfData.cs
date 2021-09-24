namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the ELF file endianness.
    /// </summary>
    public enum ElfData : byte
    {
        /// <summary>
        /// Invalid data encoding
        /// </summary>
        [Description("Invalid data encoding")]
        None,

        /// <summary>
        /// 2's complement, little endian
        /// </summary>
        [Description("2's complement, little endian")]
        Lsb,

        /// <summary>
        /// 2's complement, big endian
        /// </summary>
        [Description("2's complement, big endian")]
        Msb,
    }
}
