namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the ELF file bitness.
    /// </summary>
    public enum ElfClass : byte
    {
        /// <summary>
        /// Invalid class
        /// </summary>
        [Description("Invalid class")]
        None,

        /// <summary>
        /// 32-bit objects
        /// </summary>
        [Description("ELF32")]
        Elf32,

        /// <summary>
        /// 64-bit objects
        /// </summary>
        [Description("ELF64")]
        Elf64,
    }
}
