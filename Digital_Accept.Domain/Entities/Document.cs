namespace Digital_Accept.Domain.Entities
{
    public class Document : BaseEntity
    {
        public Document(string title, string description)
        {
            Title = title;
            Description = description;
            DateHourCriation = DateTime.Now;
            var event = new Event($"Document {title} created", EventType.Created);
            _events.Add(event);
        }

        private Document()
        {
            //Needs for Entity Framework
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime DateHourCriation { get; private set; }

        public IReadOnlyCollection<Event> Eventos => _events.AsReadOnly();
        private readonly List<Event> _events = new();

        public IReadOnlyCollection<SignataryDocument> DocumentosSignatarios =>
            _signatariesDocuments.AsReadOnly();
        private readonly List<SignataryDocument> _signatariesDocuments = new();


        public void AdicionarSignatario(Signatary signatary, SignataryType signataryType)
        {
            var signataryDocument = new SignataryDocument(signatary, signataryType);

            _signatariesDocuments.Add(signataryDocument);

            //var evento = new Evento($"Signatario {signatario.ToString()} adicionado como {tipoSignatario}.", TipoEvento.Recusado);
            //_eventos.Add(evento);
        }

        public void SignDocument(Signatary signatary)
        {
            var signataryDocument = _signatariesDocuments.Find(s => s.SignataryId == signatary.Id);
            if (signataryDocument == null)
            {
                throw new Exception("Signatary not found.");
            }
            signataryDocument.SignDocument();

            //var event = new Event($"Signatary {signatary.ToString()} signed.", EventType.Signed);
            //_events.Add(event);
        }

        public void RefuseSignatureDocument(Signatary signatary)
        {
            var signataryDocument = _signatariesDocuments.Find(s => s.SignataryId == signatary.Id);
            if (signataryDocument == null)
            {
                throw new Exception("Signatary not found.");
            }
            signataryDocument.RefuseSignature();

            //var event = new Event($"Signatary {signatary.ToString()} refused the signature.", EventType.Refused);
            //_events.Add(event);
        }
    }
}
