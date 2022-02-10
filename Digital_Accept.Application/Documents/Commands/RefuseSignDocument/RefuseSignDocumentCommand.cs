using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Documents.Commands.RefuseSignDocument
{
    public class RefuseSignDocumentCommand : IRequest
    {
        public long DocumentId { get; set; }

        public long SignataryId { get; set; }
    }
    public class RefuseSignDocumentCommandHandler : IRequestHandler<RefuseSignDocumentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefuseSignDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            RefuseSignDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDocument = _unitOfWork.GetRepository<Document>();
            var document = await repositoryDocument
               .FindBy(d => d.Id == request.DocumentId)
               .Include(d => d.SignatariesDocuments).ThenInclude(s => s.Signature)
               .Include(d => d.Events)
               .FirstAsync(cancellationToken);

            var repositorySigantary = _unitOfWork.GetRepository<Signatary>();
            var signatary = await repositorySigantary.GetByIdAsync(request.SignataryId);

            document.RefuseSignatureDocument(signatary);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
