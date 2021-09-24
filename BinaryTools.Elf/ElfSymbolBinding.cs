namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// A symbol's binding determines the linkage visibility and behavior.
    /// </summary>
    public enum ElfSymbolBinding : byte
    {
        /// <summary>
        /// Local symbols are not visible outside the object file containing their definition. Local symbols of the same name may exist in multiple files without interfering with each other.
        /// </summary>
        [Description("LOCAL")]
        Local = 0,

        /// <summary>
        /// Global symbols are visible to all object files being combined. One file's definition of a global symbol will satisfy another file's undefined reference to the same global symbol.
        /// </summary>
        [Description("GLOBAL")]
        Global,

        /// <summary>
        /// Weak symbols resemble global symbols, but their definitions have lower precedence.
        /// </summary>
        [Description("WEAK")]
        Weak,
    }
}
