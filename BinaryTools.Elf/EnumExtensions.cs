namespace BinaryTools.Elf
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    /// <summary>
    /// An extension class providing utility methods for getting <see cref="DescriptionAttribute"/> attribute strings from enum values.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the <see cref="DescriptionAttribute"/> text from an enum.
        /// </summary>
        ///
        /// <typeparam name="T">
        /// The enum type.
        /// </typeparam>
        ///
        /// <param name="enumerationValue">
        /// The enum value for which to retrieve the description from.
        /// </param>
        ///
        /// <returns>
        /// The description string if it exists; default result of <c>ToString</c> otherwise.
        /// </returns>
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            Type type = enumerationValue.GetType();

            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }

            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return enumerationValue.ToString();
        }
    }
}
