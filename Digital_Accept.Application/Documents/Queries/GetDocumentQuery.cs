using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Documents.Queries
{
    public class GetDocumentQuery : IRequest<Document>
    {
        public long DocumentId { get; set; }
    }
    public class GetDocumentQueryHandler : IRequestHandler<GetDocumentQuery, Document>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDocumentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Document> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            var repositoryDocument = _unitOfWork.GetRepository<Document>();

            var document = await repositoryDocument
                .FindBy(d => d.Id == request.DocumentId)
                .Include(d => d.SignatariesDocuments).ThenInclude(s => s.Signature)
                .Include(d => d.Events)
                .FirstAsync(cancellationToken);

            return document;
        }
    }
}
