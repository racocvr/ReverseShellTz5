namespace BinaryTools.Elf.Bit32
{
    using System.IO;

    /// <summary>
    /// Represents a 32-bit ELF segment.
    /// </summary>
    internal sealed class ElfSegment : Elf.ElfSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfSegment"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the ELF segment begins.
        /// </param>
        internal ElfSegment(BinaryReader reader, long position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf32_Phdr.p_type
            Type = (ElfSegmentType)reader.ReadUInt32();

            // Represents Elf32_Phdr.p_offset
            Offset = reader.ReadUInt32();

            // Represents Elf32_Phdr.p_vaddr
            VirtualAddress = reader.ReadUInt32();

            // Represents Elf32_Phdr.p_paddr
            PhysicalAddress = reader.ReadUInt32();

            // Represents Elf32_Phdr.p_filesz
            FileSize = reader.ReadUInt32();

            // Represents Elf32_Phdr.p_memsz
            MemorySize = reader.ReadUInt32();

            // Represents Elf32_Phdr.p_flags
            Flags = (ElfSegmentFlags)reader.ReadUInt32();

            // Represents Elf32_Phdr.p_align
            Alignment = reader.ReadUInt32();
        }
    }
}
