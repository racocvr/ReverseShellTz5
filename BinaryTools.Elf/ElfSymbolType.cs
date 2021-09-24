namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// A symbol's type provides a general classification for the associated entity.
    /// </summary>
    public enum ElfSymbolType : byte
    {
        /// <summary>
        /// The symbol's type is not specified.
        /// </summary>
        [Description("NOTYPE")]
        NoType = 0,

        /// <summary>
        /// The symbol is associated with a data object, such as a variable, an array, and so on.
        /// </summary>
        [Description("OBJECT")]
        Object,

        /// <summary>
        /// The symbol is associated with a function or other executable code.
        /// </summary>
        [Description("FUNC")]
        Func,

        /// <summary>
        /// The symbol is associated with a section. Symbol table entries of this type exist primarily for relocation and normally have STB_LOCAL binding.
        /// </summary>
        [Description("SECTION")]
        Section,

        /// <summary>
        /// Conventionally, the symbol's name gives the name of the source file associated with the object file. A file symbol has STB_LOCAL binding, its section index is SHN_ABS, and it precedes the other STB_LOCAL symbols for the file, if it is present.
        /// </summary>
        [Description("FILE")]
        File,

        /// <summary>
        /// The symbol labels an uninitialized common block.
        /// </summary>
        [Description("COMMON")]
        Common,

        /// <summary>
        /// The symbol specifies a Thread-Local Storage entity. When defined, it gives the assigned offset for the symbol, not the actual address. Symbols of type STT_TLS can be referenced by only special thread-local storage relocations and thread-local storage relocations can only reference symbols with type STT_TLS. Implementation need not support thread-local storage.
        /// </summary>
        [Description("TLS")]
        Tls,
    }
}
