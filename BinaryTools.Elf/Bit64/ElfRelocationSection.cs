namespace BinaryTools.Elf.Bit64
{
    using System.IO;

    /// <summary>
    /// Represents an ELF relocation section.
    /// </summary>
    internal sealed class ElfRelocationSection : Elf.ElfRelocationSection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfRelocationSection"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the ELF section begins.
        /// </param>
        internal ElfRelocationSection(BinaryReader reader, long position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf64_Shdr.sh_name
            NameOffset = reader.ReadUInt32();

            // Represents Elf64_Shdr.sh_type
            Type = (ElfSectionType)reader.ReadUInt32();

            // Represents Elf64_Shdr.sh_flags
            Flags = (ElfSectionFlags)reader.ReadUInt64();

            // Represents Elf64_Shdr.sh_addr
            Address = reader.ReadUInt64();

            // Represents Elf64_Shdr.sh_offset
            Offset = reader.ReadUInt64();

            // Represents Elf64_Shdr.sh_size
            Size = reader.ReadUInt64();

            // Represents Elf64_Shdr.sh_link
            Link = reader.ReadUInt32();

            // Represents Elf64_Shdr.sh_info
            Info = reader.ReadUInt32();

            // Represents Elf64_Shdr.sh_addralign
            Alignment = reader.ReadUInt64();

            // Represents Elf64_Shdr.sh_entsize
            EntrySize = reader.ReadUInt64();

            // Initialize all dynamic entries
            for (ulong i = 0; i < Size / EntrySize; i++)
            {
                var entry = new ElfRelocationEntry(reader, (long)(Offset + (i * EntrySize)), Type == ElfSectionType.RelA);

                Entries.Add(entry);
            }
        }
    }
}
