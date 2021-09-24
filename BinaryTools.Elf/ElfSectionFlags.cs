namespace BinaryTools.Elf
{
    using System;

    /// <summary>
    /// Enumerates the ELF section's contents and semantics.
    /// </summary>
    [Flags]
    public enum ElfSectionFlags : uint
    {
        /// <summary>
        /// The section contains no flags.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// The section contains data that should be writable during process execution.
        /// </summary>
        Write = 0x1,

        /// <summary>
        /// The section occupies memory during process execution. Some control sections do not reside in the memory image of an object file; this attribute is off for those sections.
        /// </summary>
        Alloc = 0x2,

        /// <summary>
        /// The section contains executable machine instructions.
        /// </summary>
        Exec = 0x4,

        /// <summary>
        /// The data in the section may be merged to eliminate duplication. Unless the SHF_STRINGS flag is also set, the data elements in the section are of a uniform size. The size of each element is specified in the section header's sh_entsize field. If the SHF_STRINGS flag is also set, the data elements consist of null-terminated character strings. The size of each character is specified in the section header's sh_entsize field.
        ///
        /// Each element in the section is compared against other elements in sections with the same name, type and flags. Elements that would have identical values at program run-time may be merged. Relocations referencing elements of such sections must be resolved to the merged locations of the referenced values. Note that any relocatable values, including values that would result in run-time relocations, must be analyzed to determine whether the run-time values would actually be identical. An ABI-conforming object file may not depend on specific elements being merged, and an ABI-conforming link editor may choose not to merge specific elements.
        /// </summary>
        Merge = 0x10,

        /// <summary>
        /// The data elements in the section consist of null-terminated character strings. The size of each character is specified in the section header's sh_entsize field.
        /// </summary>
        Strings = 0x20,

        /// <summary>
        /// The sh_info field of this section header holds a section header table index.
        /// </summary>
        InfoLink = 0x40,

        /// <summary>
        /// This flag adds special ordering requirements for link editors. The requirements apply if the sh_link field of this section's header references another section (the linked-to section). If this section is combined with other sections in the output file, it must appear in the same relative order with respect to those sections, as the linked-to section appears with respect to sections the linked-to section is combined with.
        /// </summary>
        LinkOrder = 0x80,

        /// <summary>
        /// This section requires special OS-specific processing (beyond the standard linking rules) to avoid incorrect behavior. If this section has either an sh_type value or contains sh_flags bits in the OS-specific ranges for those fields, and a link editor processing this section does not recognize those values, then the link editor should reject the object file containing this section with an error.
        /// </summary>
        OSNonConforming = 0x100,

        /// <summary>
        /// This section is a member (perhaps the only one) of a section group. The section must be referenced by a section of type SHT_GROUP. The SHF_GROUP flag may be set only for sections contained in relocatable objects (objects with the ELF header e_type member set to ET_REL).
        /// </summary>
        Group = 0x200,

        /// <summary>
        /// This section holds Thread-Local Storage, meaning that each separate execution flow has its own distinct instance of this data. Implementations need not support this flag.
        /// </summary>
        TLS = 0x400,
    }
}
