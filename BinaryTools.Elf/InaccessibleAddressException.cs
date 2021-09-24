namespace BinaryTools.Elf
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The exception that is thrown when attempting to access an illegal memory lIBM.OMR.CoreAnalyzer.ion.
    /// </summary>
    [Serializable]
    public sealed class InaccessibleAddressException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InaccessibleAddressException"/> class.
        /// </summary>
        public InaccessibleAddressException()
        {
            // Void
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InaccessibleAddressException"/> class with a specified error message.
        /// </summary>
        ///
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public InaccessibleAddressException(string message)
        : base(message)
        {
            // Void
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InaccessibleAddressException"/> class with a specified error message and a reference to the inner
        /// exception that is the cause of this exception.
        /// </summary>
        ///
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        ///
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public InaccessibleAddressException(string message, Exception innerException)
        : base(message, innerException)
        {
            // Void
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InaccessibleAddressException"/> class with serialized data.
        /// </summary>
        ///
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        ///
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="info"/> parameter is <c>null</c>.
        /// </exception>
        ///
        /// <exception cref="SerializationException">
        /// Thrown when the class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
        /// </exception>
        private InaccessibleAddressException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
            // Void
        }
    }
}
