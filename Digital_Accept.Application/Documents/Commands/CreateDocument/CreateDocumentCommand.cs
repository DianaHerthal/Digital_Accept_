using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;

namespace Digital_Accept.Application.Documents.Commands.CreateDocument
{
    public class CreateDocumentCommand : IRequest<Document>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, Document>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Document> Handle(
            CreateDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var insertDocument = new Document(request.Title, request.Description);

            var repositoryDocument = _unitOfWork.GetRepository<Document>();

            repositoryDocument.Add(insertDocument);

            await _unitOfWork.CommitAsync();

            return insertDocument;
        }
    }
}
