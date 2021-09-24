namespace BinaryTools.Elf.Bit64
{
    using System.IO;

    /// <summary>
    /// Represents a 64-bit ELF header.
    /// </summary>
    internal sealed class ElfHeader : Elf.ElfHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfHeader"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the ELF header begins.
        /// </param>
        internal ElfHeader(BinaryReader reader, long position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf64_Ehdr.e_ident[0]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[1]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[2]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[3]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[4]
            Class = (ElfClass)reader.ReadByte();

            // Represents Elf32_Ehdr.e_ident[5]
            Data = (ElfData)reader.ReadByte();

            // Represents Elf64_Ehdr.e_ident[6]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[7]
            OSABI = (ElfOSABI)reader.ReadByte();

            // Represents Elf64_Ehdr.e_ident[8]
            OSABIVersion = reader.ReadByte();

            // Represents Elf64_Ehdr.e_ident[9]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[10]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[11]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[12]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[13]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[14]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_ident[15]
            reader.BaseStream.Position += 1;

            // Represents Elf64_Ehdr.e_type
            Type = (ElfType)reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_machine
            Machine = (ElfMachine)reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_version
            Version = reader.ReadUInt32();

            // Represents Elf64_Ehdr.e_entry
            EntryOffset = reader.ReadUInt64();

            // Represents Elf64_Ehdr.e_phoff
            ProgramHeaderOffset = reader.ReadUInt64();

            // Represents Elf64_Ehdr.e_shoff
            SectionHeaderOffset = reader.ReadUInt64();

            // Represents Elf64_Ehdr.e_flags
            Flags = reader.ReadUInt32();

            // Represents Elf64_Ehdr.e_ehsize
            Size = reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_phentsize
            ProgramHeaderSize = reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_phnum
            ProgramHeaderEntryCount = reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_shentsize
            SectionHeaderSize = reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_shnum
            SectionHeaderEntryCount = reader.ReadUInt16();

            // Represents Elf64_Ehdr.e_shstrnds
            StringSectionIndex = reader.ReadUInt16();
        }
    }
}
