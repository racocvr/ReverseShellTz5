namespace BinaryTools.Elf
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// An extension class providing <see cref="BinaryReader"/> utility methods for extracting ELF specific data.
    /// </summary>
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Reads a string value from the binary reader.
        /// </summary>
        ///
        /// <param name="reader">
        /// The binary reader used to extract data.
        /// </param>
        ///
        /// <returns>
        /// The string value.
        /// </returns>
        ///
        /// <remarks>
        /// The string is defined as a null terminated sequence of character values.
        /// </remarks>
        public static string ReadELFString(this BinaryReader reader)
        {
            StringBuilder builder = new StringBuilder();

            char c = (char)reader.ReadByte();

            // Read the entire null terminated string
            while (c != 0)
            {
                builder.Append(c);
                c = (char)reader.ReadByte();
            }

            return builder.ToString();
        }

        /// <summary>
        /// Reads a string value from an index into the ELF string table section.
        /// </summary>
        ///
        /// <param name="reader">
        /// The binary reader used to extract data.
        /// </param>
        ///
        /// <param name="section">
        /// The ELF string table section.
        /// </param>
        ///
        /// <param name="offset">
        /// The offset of the string in the ELF string table section.
        /// </param>
        ///
        /// <returns>
        /// The string value extracted from the ELF string table section at the specified offset.
        /// </returns>
        ///
        /// <remarks>
        /// The string is defined as a null terminated sequence of character values.
        /// </remarks>
        public static string ReadELFString(this BinaryReader reader, ElfSection section, ulong offset)
        {
            string value = string.Empty;

            if (section != null && offset < section.Size)
            {
                long savedPosition = reader.BaseStream.Position;

                reader.BaseStream.Position = (long)(section.Offset + offset);

                // Read the entire null terminated string
                value = reader.ReadELFString();

                reader.BaseStream.Position = savedPosition;
            }

            return value;
        }
    }
}
