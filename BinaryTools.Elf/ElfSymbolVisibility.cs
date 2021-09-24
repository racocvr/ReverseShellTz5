namespace BinaryTools.Elf
{
    using System.ComponentModel;

    /// <summary>
    /// A symbol's visibility, although it may be specified in a relocatable object, defines how that symbol may be accessed once it has become part of an executable or shared object.
    /// </summary>
    public enum ElfSymbolVisibility : byte
    {
        /// <summary>
        /// The visibility of symbols with the STV_DEFAULT attribute is as specified by the symbol's binding type. That is, global and weak symbols are visible outside of their defining component (executable file or shared object). Local symbols are hidden. Global and weak symbols are also preemptable, that is, they may by preempted by definitions of the same name in another component.
        /// </summary>
        [Description("DEFAULT")]
        Default = 0,

        /// <summary>
        /// A symbol defined in the current component is protected if it is visible in other components but not preemptable, meaning that any reference to such a symbol from within the defining component must be resolved to the definition in that component, even if there is a definition in another component that would preempt by the default rules. A symbol with STB_LOCAL binding may not have STV_PROTECTED visibility. If a symbol definition with STV_PROTECTED visibility from a shared object is taken as resolving a reference from an executable or another shared object, the SHN_UNDEF symbol table entry created has STV_DEFAULT visibility.
        /// </summary>
        [Description("INTERNAL")]
        Internal,

        /// <summary>
        /// A symbol defined in the current component is hidden if its name is not visible to other components. Such a symbol is necessarily protected. This attribute may be used to control the external interface of a component. Note that an object named by such a symbol may still be referenced from another component if its address is passed outside.
        ///
        /// A hidden symbol contained in a relocatable object must be either removed or converted to STB_LOCAL binding by the link-editor when the relocatable object is included in an executable file or shared object.
        /// </summary>
        [Description("HIDDEN")]
        Hidden,

        /// <summary>
        /// The meaning of this visibility attribute may be defined by processor supplements to further constrain hidden symbols. A processor supplement's definition should be such that generic tools can safely treat internal symbols as hidden.
        ///
        /// An internal symbol contained in a relocatable object must be either removed or converted to STB_LOCAL binding by the link-editor when the relocatable object is included in an executable file or shared object.
        /// </summary>
        [Description("PROTECTED")]
        Protected,
    }
}
