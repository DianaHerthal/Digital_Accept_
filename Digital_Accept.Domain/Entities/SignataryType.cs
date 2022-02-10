namespace Digital_Accept.Domain.Entities
{
    /// <summary>
    /// Document signer roles
    /// </summary>
    public enum SignataryType
    {
        /// <summary>
        /// Parts belonging to the document.
        /// </summary>
        Part,

        /// <summary>
        /// Witness the signature of the document.
        /// </summary>
        Witness
    }
}
