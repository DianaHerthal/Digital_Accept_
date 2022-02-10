using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Documents.Commands.AddSignatary
{
    internal class AddSignataryCommand : IRequest
    {
        public long DocumentId { get; set; }

        public long SignataryId { get; set; }

        public char SignataryType { get; set; }
    }
    public class AddSignataryCommandHandler : IRequestHandler<AddSignataryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSignataryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            AddSignataryCommand request,
            CancellationToken cancellationToken)
        {
            var repositoryDocument = _unitOfWork.GetRepository<Document>();
            var document = await repositoryDocument
               .FindBy(d => d.Id == request.DocumentId)
               .Include(d => d.SignatariesDocuments)
               .Include(d => d.Events)
               .FirstAsync(cancellationToken);

            var repositorySigantary = _unitOfWork.GetRepository<Signatary>();
            var signatary = await repositorySigantary.GetByIdAsync(request.SignataryId);

            var signataryType = request.SignataryType == 'P' ? SignataryType.Part : SignataryType.Witness;

            document.AddSignatary(signatary, signataryType);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

    }
}
