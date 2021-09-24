namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the dynamic section entry tags which are used to interpret the entry values.
    /// </summary>
    public enum ElfDynamicArrayTag : long
    {
        /// <summary>
        /// An entry with a DT_NULL tag marks the end of the _DYNAMIC array.
        /// </summary>
        [Description("NULL")]
        Null,

        /// <summary>
        /// This element holds the string table offset of a null-terminated string, giving the name of a needed library. The offset is an index into the table recorded in the DT_STRTAB code. The dynamic array may contain multiple entries with this type. These entries' relative order is significant, though their relation to entries of other types is not.
        /// </summary>
        [Description("NEEDED")]
        Needed,

        /// <summary>
        /// This element holds the total size, in bytes, of the relocation entries associated with the procedure linkage table. If an entry of type DT_JMPREL is present, a DT_PLTRELSZ must accompany it.
        /// </summary>
        [Description("PLTRELSZ")]
        PltRelSz,

        /// <summary>
        /// This element holds an address associated with the procedure linkage table and/or the global offset table.
        /// </summary>
        [Description("PLTGOT")]
        PltGot,

        /// <summary>
        /// This element holds the address of the symbol hash table. This hash table refers to the symbol table referenced by the DT_SYMTAB element.
        /// </summary>
        [Description("HASH")]
        Hash,

        /// <summary>
        /// This element holds the address of the string table. Symbol names, library names, and other strings reside in this table.
        /// </summary>
        [Description("STRTAB")]
        StrTab,

        /// <summary>
        /// This element holds the address of the symbol table.
        /// </summary>
        [Description("SYMTAB")]
        SymTab,

        /// <summary>
        /// This element holds the address of a relocation table. Entries in the table have explicit addends, such as Elf32_Rela for the 32-bit file class or Elf64_Rela for the 64-bit file class. An object file may have multiple relocation sections. When building the relocation table for an executable or shared object file, the link editor catenates those sections to form a single table. Although the sections remain independent in the object file, the dynamic linker sees a single table. When the dynamic linker creates the process image for an executable file or adds a shared object to the process image, it reads the relocation table and performs the associated actions. If this element is present, the dynamic structure must also have DT_RELASZ and DT_RELAENT elements. When relocation is ``mandatory'' for a file, either DT_RELA or DT_REL may occur (both are permitted but not required).
        /// </summary>
        [Description("RELA")]
        RelA,

        /// <summary>
        /// This element holds the total size, in bytes, of the DT_RELA relocation table.
        /// </summary>
        [Description("RELASZ")]
        RelASz,

        /// <summary>
        /// This element holds the size, in bytes, of the DT_RELA relocation entry.
        /// </summary>
        [Description("RELAENT")]
        RelAEnt,

        /// <summary>
        /// This element holds the size, in bytes, of the string table.
        /// </summary>
        [Description("STRSZ")]
        StrSz,

        /// <summary>
        /// This element holds the size, in bytes, of a symbol table entry.
        /// </summary>
        [Description("SYMENT")]
        SymEnt,

        /// <summary>
        /// This element holds the address of the initialization function.
        /// </summary>
        [Description("INIT")]
        Init,

        /// <summary>
        /// This element holds the address of the termination function.
        /// </summary>
        [Description("FINI")]
        Fini,

        /// <summary>
        /// This element holds the string table offset of a null-terminated string, giving the name of the shared object. The offset is an index into the table recorded in the DT_STRTAB entry.
        /// </summary>
        [Description("SONAME")]
        SOName,

        /// <summary>
        /// This element holds the string table offset of a null-terminated search library search path string. The offset is an index into the table recorded in the DT_STRTAB entry. This entry is at level 2. Its use has been superseded by DT_RUNPATH.
        /// </summary>
        [Description("RPATH")]
        RPath,

        /// <summary>
        /// This element's presence in a shared object library alters the dynamic linker's symbol resolution algorithm for references within the library. Instead of starting a symbol search with the executable file, the dynamic linker starts from the shared object itself. If the shared object fails to supply the referenced symbol, the dynamic linker then searches the executable file and other shared objects as usual. This entry is at level 2. Its use has been superseded by the DF_SYMBOLIC flag.
        /// </summary>
        [Description("SYMBOLIC")]
        Symbolic,

        /// <summary>
        /// This element is similar to DT_RELA, except its table has implicit addends, such as Elf32_Rel for the 32-bit file class or Elf64_Rel for the 64-bit file class. If this element is present, the dynamic structure must also have DT_RELSZ and DT_RELENT elements.
        /// </summary>
        [Description("REL")]
        Rel,

        /// <summary>
        /// This element holds the total size, in bytes, of the DT_REL relocation table.
        /// </summary>
        [Description("RELSZ")]
        RelSz,

        /// <summary>
        /// This element holds the size, in bytes, of the DT_REL relocation entry.
        /// </summary>
        [Description("RELENT")]
        RelEnt,

        /// <summary>
        /// This member specifies the type of relocation entry to which the procedure linkage table refers. The d_val member holds DT_REL or DT_RELA, as appropriate. All relocations in a procedure linkage table must use the same relocation.
        /// </summary>
        [Description("PLTREL")]
        PltRel,

        /// <summary>
        /// This member is used for debugging. Its contents are not specified for the ABI; programs that access this entry are not ABI-conforming.
        /// </summary>
        [Description("DEBUG")]
        Debug,

        /// <summary>
        /// This member's absence signifies that no relocation entry should cause a modification to a non-writable segment, as specified by the segment permissions in the program header table. If this member is present, one or more relocation entries might request modifications to a non-writable segment, and the dynamic linker can prepare accordingly. This entry is at level 2. Its use has been superseded by the DF_TEXTREL flag.
        /// </summary>
        [Description("TEXTREL")]
        TextRel,

        /// <summary>
        /// If present, this entry's d_ptr member holds the address of relocation entries associated solely with the procedure linkage table. Separating these relocation entries lets the dynamic linker ignore them during process initialization, if lazy binding is enabled. If this entry is present, the related entries of types DT_PLTRELSZ and DT_PLTREL must also be present.
        /// </summary>
        [Description("JMPREL")]
        JmpRel,

        /// <summary>
        /// If present in a shared object or executable, this entry instructs the dynamic linker to process all relocations for the object containing this entry before transferring control to the program. The presence of this entry takes precedence over a directive to use lazy binding for this object when specified through the environment or via dlopen(BA_LIB). This entry is at level 2. Its use has been superseded by the DF_BIND_NOW flag.
        /// </summary>
        [Description("BIND_NOW")]
        BindNow,

        /// <summary>
        /// This element holds the address of the array of pointers to initialization functions.
        /// </summary>
        [Description("INIT_ARRAY")]
        InitArray,

        /// <summary>
        /// This element holds the address of the array of pointers to termination functions.
        /// </summary>
        [Description("FINI_ARRAY")]
        FiniArray,

        /// <summary>
        /// This element holds the size in bytes of the array of initialization functions pointed to by the DT_INIT_ARRAY entry. If an object has a DT_INIT_ARRAY entry, it must also have a DT_INIT_ARRAYSZ entry.
        /// </summary>
        [Description("INIT_ARRAYSZ")]
        InitArraySz,

        /// <summary>
        /// This element holds the size in bytes of the array of termination functions pointed to by the DT_FINI_ARRAY entry. If an object has a DT_FINI_ARRAY entry, it must also have a DT_FINI_ARRAYSZ entry.
        /// </summary>
        [Description("FINI_ARRAYSZ")]
        FiniArraySz,

        /// <summary>
        /// This element holds the string table offset of a null-terminated library search path string. The offset is an index into the table recorded in the DT_STRTAB entry.
        /// </summary>
        [Description("RUNPATH")]
        RunPath,

        /// <summary>
        /// This element holds flag values specific to the object being loaded. Each flag value will have the name DF_flag_name.
        /// </summary>
        [Description("FLAGS")]
        Flags,

        /// <summary>
        /// This element holds the address of the array of pointers to pre-initialization functions. The DT_PREINIT_ARRAY table is processed only in an executable file; it is ignored if contained in a shared object.
        /// </summary>
        [Description("PREINIT_ARRAY")]
        PreInitArray,

        /// <summary>
        /// This element holds the size in bytes of the array of pre-initialization functions pointed to by the DT_PREINIT_ARRAY entry. If an object has a DT_PREINIT_ARRAY entry, it must also have a DT_PREINIT_ARRAYSZ entry. As with DT_PREINIT_ARRAY, this entry is ignored if it appears in a shared object.
        /// </summary>
        [Description("PREINIT_ARRAYSZ")]
        PreInitArraySz,

        /// <summary>
        /// Values greater than or equal to DT_ENCODING and less than DT_LOOS follow the rules for the interpretation of the d_un union.
        /// </summary>
        [Description("ENCODING")]
        Encoding,
    }
}
