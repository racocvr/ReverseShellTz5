namespace BinaryTools.Elf.Bit64
{
    using System.IO;

    /// <summary>
    /// Represents an ELF dynamic entry.
    /// </summary>
    internal sealed class ElfDynamicEntry : Elf.ElfDynamicEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfDynamicEntry"/> class by extracting data from a <see cref="BinaryReader"/>.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to initialize this type.
        /// </param>
        ///
        /// <param name="position">
        /// The position within the <paramref name="reader"/> base stream at which the entry begins.
        /// </param>
        internal ElfDynamicEntry(BinaryReader reader, long position)
        {
            reader.BaseStream.Position = position;

            // Represents Elf64_Dyn.d_tag
            Tag = (ElfDynamicArrayTag)reader.ReadUInt64();

            // Represents Elf64_Dyn.d_val
            Value = reader.ReadUInt64();

            Name = string.Empty;
        }
    }
}
