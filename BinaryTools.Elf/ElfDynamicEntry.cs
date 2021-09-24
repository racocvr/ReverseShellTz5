namespace BinaryTools.Elf
{
    /// <summary>
    /// Represents an ELF dynamic entry.
    /// </summary>
    public abstract class ElfDynamicEntry
    {
        /// <summary>
        /// Gets or sets the tag which controls the interpretation of the <see cref="Value"/>.
        /// </summary>
        public ElfDynamicArrayTag Tag
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets an integer value with various interpretations, including program virtual addresses.
        /// </summary>
        public ulong Value
        {
            get; protected set;
        }

        /// <summary>
        /// Gets the string value of this entry if the <see cref="Tag"/> indicates that the <see cref="Value"/> holds
        /// an index into the table recorded in the DT_STRTAB entry.
        /// </summary>
        public string Name
        {
            get; internal set;
        }
    }
}
