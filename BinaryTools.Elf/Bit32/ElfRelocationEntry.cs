namespace BinaryTools.Elf.Bit32
{
    using System.IO;

    /// <summary>
    /// Represents an ELF relocation entry.
    /// </summary>
    internal sealed class ElfRelocationEntry : Elf.ElfRelocationEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfRelocationEntry"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the entry begins.
        /// </param>
        ///
        /// <param name="hasAddend">
        /// Determines whether to parse the addend field.
        /// </param>
        internal ElfRelocationEntry(BinaryReader reader, long position, bool hasAddend)
        {
            reader.BaseStream.Position = position;

            // Represents Elf32_Rel(a).r_offset
            Offset = reader.ReadUInt32();

            // Represents Elf32_Rel(a).r_info
            Info = reader.ReadUInt32();

            // Represents ELF32_R_SYM(i)
            SymbolIndex = (int)(Info >> 8);

            // Represents ELF32_R_TYPE(i)
            Type = (uint)(Info & 0xFFUL);

            if (hasAddend)
            {
                Addend = reader.ReadUInt32();
            }

            Symbol = string.Empty;
        }
    }
}
