namespace BinaryTools.Elf
{
    /// <summary>
    /// Enumerates the ELF section's contents and semantics.
    /// </summary>
    public enum ElfSectionType : uint
    {
        /// <summary>
        /// This value marks the section header as inactive; it does not have an associated section. Other members of the section header have undefined values.
        /// </summary>
        Null = 0,

        /// <summary>
        /// The section holds information defined by the program, whose format and meaning are determined solely by the program.
        /// </summary>
        ProgBits = 1,

        /// <summary>
        /// These sections hold a symbol table. Currently, an object file may have only one section of each type, but this restriction may be relaxed in the future. Typically, SHT_SYMTAB provides symbols for link editing, though it may also be used for dynamic linking. As a complete symbol table, it may contain many symbols unnecessary for dynamic linking. Consequently, an object file may also contain a SHT_DYNSYM section, which holds a minimal set of dynamic linking symbols, to save space.
        /// </summary>
        SymTab = 2,

        /// <summary>
        /// The section holds a string table. An object file may have multiple string table sections.
        /// </summary>
        StrTab = 3,

        /// <summary>
        /// The section holds relocation entries with explicit addends, such as type Elf32_Rela for the 32-bit class of object files or type Elf64_Rela for the 64-bit class of object files. An object file may have multiple relocation sections.
        /// </summary>
        RelA = 4,

        /// <summary>
        /// The section holds a symbol hash table. Currently, an object file may have only one hash table, but this restriction may be relaxed in the future.
        /// </summary>
        Hash = 5,

        /// <summary>
        /// The section holds information for dynamic linking. Currently, an object file may have only one dynamic section, but this restriction may be relaxed in the future.
        /// </summary>
        Dynamic = 6,

        /// <summary>
        /// The section holds information that marks the file in some way.
        /// </summary>
        Note = 7,

        /// <summary>
        /// A section of this type occupies no space in the file but otherwise resembles SHT_PROGBITS. Although this section contains no bytes, the sh_offset member contains the conceptual file offset.
        /// </summary>
        NoBits = 8,

        /// <summary>
        /// The section holds relocation entries without explicit addends, such as type Elf32_Rel for the 32-bit class of object files or type Elf64_Rel for the 64-bit class of object files. An object file may have multiple relocation sections.
        /// </summary>
        Rel = 9,

        /// <summary>
        /// This section type is reserved but has unspecified semantics.
        /// </summary>
        ShLib = 10,

        /// <summary>
        /// These sections hold a symbol table. Currently, an object file may have only one section of each type, but this restriction may be relaxed in the future. Typically, SHT_SYMTAB provides symbols for link editing, though it may also be used for dynamic linking. As a complete symbol table, it may contain many symbols unnecessary for dynamic linking. Consequently, an object file may also contain a SHT_DYNSYM section, which holds a minimal set of dynamic linking symbols, to save space.
        /// </summary>
        DynSym = 11,

        /// <summary>
        /// This section contains an array of pointers to initialization functions.
        /// </summary>
        InitArray = 14,

        /// <summary>
        /// This section contains an array of pointers to termination functions.
        /// </summary>
        FiniArray = 15,

        /// <summary>
        /// This section contains an array of pointers to functions that are invoked before all other initialization functions.
        /// </summary>
        PreInitArray = 16,

        /// <summary>
        /// This section defines a section group. A section group is a set of sections that are related and that must be treated specially by the linker. Sections of type SHT_GROUP may appear only in relocatable objects (objects with the ELF header e_type member set to ET_REL). The section header table entry for a group section must appear in the section header table before the entries for any of the sections that are members of the group.
        /// </summary>
        Group = 17,

        /// <summary>
        /// This section is associated with a section of type SHT_SYMTAB and is required if any of the section header indexes referenced by that symbol table contain the escape value SHN_XINDEX. The section is an array of Elf32_Word values. Each value corresponds one to one with a symbol table entry and appear in the same order as those entries. The values represent the section header indexes against which the symbol table entries are defined. Only if corresponding symbol table entry's st_shndx field contains the escape value SHN_XINDEX will the matching Elf32_Word hold the actual section header index; otherwise, the entry must be SHN_UNDEF (0).
        /// </summary>
        SymTabShndx = 18,
    }
}
