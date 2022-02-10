namespace Digital_Accept.Domain.Entities
{
    /// <summary>
    /// Types of events performed with the document.
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// When a document is created.
        /// </summary>
        Created,

        /// <summary>
        /// When one or more signers are added to the document.
        /// </summary>
        AddSignatary,

        /// <summary>
        /// When a document is signed.
        /// </summary>
        Signed,

        /// <summary>
        /// When the signer refuses to sign the document.
        /// </summary>
        Refused
    }
}
