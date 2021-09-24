namespace BinaryTools.Elf.Bit32
{
    using System.IO;

    /// <summary>
    /// Represents an ELF symbol table entry.
    /// </summary>
    internal sealed class ElfSymbolTableEntry : Elf.ElfSymbolTableEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfSymbolTableEntry"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the entry begins.
        /// </param>
        internal ElfSymbolTableEntry(BinaryReader reader, long position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf32_Sym.st_name
            NameIndex = reader.ReadUInt32();

            // Represents Elf32_Sym.st_value
            Value = reader.ReadUInt32();

            // Represents Elf32_Sym.st_size
            Size = reader.ReadUInt32();

            // Represents Elf32_Sym.st_info
            byte info = reader.ReadByte();

            // Represents ELF32_ST_BIND(i)
            Binding = (ElfSymbolBinding)(info >> 4);

            // Represents ELF32_ST_TYPE(i)
            Type = (ElfSymbolType)(info & 0x0F);

            // Represents Elf32_Sym.st_other
            Visibility = (ElfSymbolVisibility)reader.ReadByte();

            // Represents Elf32_Sym.st_size
            ShIndex = reader.ReadUInt16();

            Name = string.Empty;
        }
    }
}
