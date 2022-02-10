namespace Digital_Accept.Domain.Entities
{
    public class Signatary : BaseEntity
    {
        public Signatary(string cpf, string name, string email)
        {
            Cpf = cpf;
            Name = name;
            Email = email;
        }

        public Signatary()
        {
            //Necessário para o entity framework
        }

        public string Cpf { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public IReadOnlyCollection<SignataryDocument> SignatariesDocuments =>
            _signatariesDocuments.AsReadOnly();
        private readonly List<SignataryDocument> _signatariesDocuments = new();

        public string ToString()
        {
            return $"Name {Name} CPF {Cpf} e-mail {Email}";
        }
    }
}
