using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Documents.Commands.SignDocument
{
    public class SignDocumentCommand : IRequest
    {
        public long DocumentId { get; set; }

        public long SignataryId { get; set; }
    }
    public class SignDocumentCommandHandler : IRequestHandler<SignDocumentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            SignDocumentCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDocument = _unitOfWork.GetRepository<Document>();
            var document = await repositoryDocument
                .FindBy(d => d.Id == request.DocumentId)
                .Include(d => d.SignatariesDocuments).ThenInclude(s => s.Signature)
                //.Include(d => d.Eventos)
                .FirstAsync(cancellationToken);

            var repositorySigantary = _unitOfWork.GetRepository<Signatary>();
            var signatary = await repositorySigantary.GetByIdAsync(request.SignataryId);

            document.SignDocument(signatary);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
