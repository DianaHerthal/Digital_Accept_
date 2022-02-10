namespace Digital_Accept.Domain.Entities
{
    public class Signature : BaseEntity
    {
        public Signature()
        {
            DateHourRegister = DateTime.Now;
        }

        public long SignataryDocumentId { get; private set; }

        public DateTime DateHourRegister { get; private set; }

        public bool Accept { get; private set; }

        public SignataryDocument SignataryDocument { get; private set; }

        protected internal void Sign()
        {
            Accept = true;
        }

        protected internal void RefuseSignature()
        {
            Accept = false;
        }
    }
}
