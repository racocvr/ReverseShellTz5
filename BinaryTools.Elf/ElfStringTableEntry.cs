namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF string table entry.
    /// </summary>
    public class ElfStringTableEntry
    {
        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets index (in number of bytes) from the start of the string table section to this string entry.
        /// </summary>
        public uint Index
        {
            get; set;
        }
    }
}
