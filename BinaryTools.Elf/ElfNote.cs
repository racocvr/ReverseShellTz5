namespace BinaryTools.Elf
{
    using System.IO;
    using BinaryTools.Elf.Io;

    /// <summary>
    /// Represents an ELF note which contains auxiliary information.
    /// </summary>
    public sealed class ElfNote
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfNote"/> class.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader used to extract the data needed to parse the ELF note.
        /// </param>
        internal ElfNote(BinaryReader reader)
        {
            // Represents Elf_Note.namesz
            reader.BaseStream.Position += 4;

            // Represents Elf_Note.descsz
            DescriptionSize = reader.ReadUInt32();

            // Represents Elf_Note.type
            Type = reader.ReadUInt32();

            Name = reader.ReadELFString();

            // Align after reading the name
            reader.BaseStream.Position = (reader.BaseStream.Position + 3) / 4 * 4;

            // Record the read offset of the description
            DescriptionOffset = (ulong)reader.BaseStream.Position;

            reader.BaseStream.Position += DescriptionSize;

            // Align after reading the description
            reader.BaseStream.Position = (reader.BaseStream.Position + 3) / 4 * 4;
        }

        /// <summary>
        /// Gets the name of the note.
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// Gets the type of the note which gives interpretation of the description.
        /// </summary>
        public uint Type
        {
            get;
        }

        /// <summary>
        /// Gets the size in number of bytes of the note description.
        /// </summary>
        public uint DescriptionSize
        {
            get;
        }

        /// <summary>
        /// Gets the description of the note.
        /// </summary>
        public ulong DescriptionOffset
        {
            get;
        }

        /// <summary>
        /// Reads an ELF note from a binary reader whose base stream position points to an ELF note section.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader whose base stream position points to an ELF note section.
        /// </param>
        ///
        /// <param name="section">
        /// The section to read the ELF note from.
        /// </param>
        ///
        /// <returns>
        /// The ELF note parsed from the section.
        /// </returns>
        ///
        /// <exception cref="FileFormatException">
        /// <paramref name="reader"/> base stream does not represent a valid ELF note.
        /// </exception>
        public static ElfNote ReadElfNote(BinaryReader reader, ElfSection section)
        {
            try
            {
                if (reader.BaseStream.Position < (long)(section.Offset + section.Size))
                {
                    return new ElfNote(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (InaccessibleAddressException exception)
            {
                throw new FileFormatException(exception.Message, exception);
            }
        }

        /// <summary>
        /// Reads an ELF note from a binary reader whose base stream position points to an ELF note segment.
        /// </summary>
        ///
        /// <param name="reader">
        /// The reader whose base stream position points to an ELF note segment.
        /// </param>
        ///
        /// <param name="segment">
        /// The segment to read the ELF note from.
        /// </param>
        ///
        /// <returns>
        /// The ELF note parsed from the segment.
        /// </returns>
        ///
        /// <exception cref="FileFormatException">
        /// <paramref name="reader"/> base stream does not represent a valid ELF note.
        /// </exception>
        public static ElfNote ReadElfNote(BinaryReader reader, ElfSegment segment)
        {
            try
            {
                if (reader.BaseStream.Position < (long)(segment.Offset + segment.FileSize))
                {
                    return new ElfNote(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (InaccessibleAddressException exception)
            {
                throw new FileFormatException(exception.Message, exception);
            }
        }
    }
}
