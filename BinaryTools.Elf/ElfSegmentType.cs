namespace BinaryTools.Elf
{
    /// <summary>
    /// Enumerates the ELF segment's contents and semantics.
    /// </summary>
    public enum ElfSegmentType : uint
    {
        /// <summary>
        /// The array element is unused; other members' values are undefined. This type lets the program header table have ignored entries.
        /// </summary>
        Null = 0,

        /// <summary>
        /// The array element specifies a loadable segment, described by p_filesz and p_memsz. The bytes from the file are mapped to the beginning of the memory segment. If the segment's memory size (p_memsz) is larger than the file size (p_filesz), the "extra" bytes are defined to hold the value 0 and to follow the segment's initialized area. The file size may not be larger than the memory size. Loadable segment entries in the program header table appear in ascending order, sorted on the p_vaddr member.
        /// </summary>
        Load = 1,

        /// <summary>
        /// The array element specifies dynamic linking information.
        /// </summary>
        Dynamic = 2,

        /// <summary>
        /// The array element specifies the location and size of a null-terminated path name to invoke as an interpreter. This segment type is meaningful only for executable files (though it may occur for shared objects); it may not occur more than once in a file. If it is present, it must precede any loadable segment entry.
        /// </summary>
        Interp = 3,

        /// <summary>
        /// The array element specifies the location and size of auxiliary information.
        /// </summary>
        Note = 4,

        /// <summary>
        /// This segment type is reserved but has unspecified semantics. Programs that contain an array element of this type do not conform to the ABI.
        /// </summary>
        ShLib = 5,

        /// <summary>
        /// The array element, if present, specifies the location and size of the program header table itself, both in the file and in the memory image of the program. This segment type may not occur more than once in a file. Moreover, it may occur only if the program header table is part of the memory image of the program. If it is present, it must precede any loadable segment entry.
        /// </summary>
        PHdr = 6,

        /// <summary>
        /// The array element specifies the Thread-Local Storage template. Implementations need not support this program table entry.
        /// </summary>
        TLS = 7,
    }
}
