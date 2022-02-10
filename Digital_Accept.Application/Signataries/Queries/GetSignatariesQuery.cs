using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Signataries.Queries
{
    public class GetSignatariesQuery : IRequest<List<Signatary>>
    {
    }
    public class GetSignatariesQueryHandler :
        IRequestHandler<GetSignatariesQuery, List<Signatary>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSignatariesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Signatary>> Handle(
            GetSignatariesQuery request,
            CancellationToken cancellationToken)
        {
            var repositorySigantary =
                _unitOfWork.GetRepository<Signatary>();

            var signataries = await repositorySigantary
                .GetAll()
                .ToListAsync(cancellationToken);

            return signataries;
        }
    }
}
