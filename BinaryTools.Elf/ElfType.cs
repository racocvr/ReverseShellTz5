namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the object file type.
    /// </summary>
    public enum ElfType : ushort
    {
        /// <summary>
        /// No file type
        /// </summary>
        [Description("No file type")]
        None,

        /// <summary>
        /// Relocatable file
        /// </summary>
        [Description("Relocatable file")]
        Relocatable,

        /// <summary>
        /// Executable file
        /// </summary>
        [Description("Executable file")]
        Executable,

        /// <summary>
        /// Shared object file
        /// </summary>
        [Description("Shared object file")]
        Shared,

        /// <summary>
        /// Core file
        /// </summary>
        [Description("Core file")]
        Core,
    }
}
