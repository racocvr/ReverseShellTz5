namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// Enumerates the OS- or ABI-specific ELF extensions.
    /// </summary>
    public enum ElfOSABI : byte
    {
        /// <summary>
        /// No extensions or unspecified
        /// </summary>
        [Description("No extensions or unspecified")]
        None,

        /// <summary>
        /// Hewlett-Packard HP-UX
        /// </summary>
        [Description("Hewlett-Packard HP-UX")]
        HPUX,

        /// <summary>
        /// NetBSD
        /// </summary>
        [Description("NetBSD")]
        NetBSD,

        /// <summary>
        /// Linux
        /// </summary>
        [Description("Linux")]
        Linux,

        /// <summary>
        /// Sun Solaris
        /// </summary>
        [Description("Sun Solaris")]
        Solaris,

        /// <summary>
        /// AIX
        /// </summary>
        [Description("AIX")]
        AIX,

        /// <summary>
        /// IRIX
        /// </summary>
        [Description("IRIX")]
        IRIX,

        /// <summary>
        /// FreeBSD
        /// </summary>
        [Description("FreeBSD")]
        FreeBSD,

        /// <summary>
        /// Compaq TRU64 UNIX
        /// </summary>
        [Description("Compaq TRU64 UNIX")]
        TRU64,

        /// <summary>
        /// Novell Modesto
        /// </summary>
        [Description("Novell Modesto")]
        Modesto,

        /// <summary>
        /// Open BSD
        /// </summary>
        [Description("Open BSD")]
        OpenBSD,

        /// <summary>
        /// Open VMS
        /// </summary>
        [Description("Open VMS")]
        OpenVMS,

        /// <summary>
        /// Hewlett-Packard Non-Stop Kernel
        /// </summary>
        [Description("Hewlett-Packard Non-Stop Kernel")]
        NSK,
    }
}
