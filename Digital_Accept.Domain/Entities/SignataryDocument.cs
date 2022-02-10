namespace Digital_Accept.Domain.Entities
{
    public class SignataryDocument : BaseEntity
    {
        public SignataryDocument(Signatary signatary, SignataryType signataryType)
        {
            SignataryId = signatary.Id;
            Signatary = signatary;
            SignataryType = signataryType;
        }

        public SignataryDocument()
        {
            //Need for entity framework
        }

        public long DocumentId { get; private set; }

        public long SignataryId { get; private set; }

        public SignataryType SignataryType { get; private set; }

        public Document Document { get; private set; }

        public Signatary Signatary { get; private set; }

        public Signature Signature { get; private set; }

        public void SignDocument()
        {
            Signature ??= new Signature();

            Signature.Sign();
        }

        public void RefuseSignature()
        {
            Signature ??= new Signature();

            Signature.RefuseSignature();
        }
    }
}
