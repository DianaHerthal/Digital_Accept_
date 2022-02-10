using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;

namespace Digital_Accept.Application.Signataries.Commands.CreateSignatary
{
    public class CreateSignataryCommand : IRequest<Signatary>
    {
        public string Cpf { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
    public class CreateSignataryCommandHandler : IRequestHandler<CreateSignataryCommand, Signatary>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSignataryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Signatary> Handle(
            CreateSignataryCommand request,
            CancellationToken cancellationToken)
        {
            var insertSignatary = new Signatary(request.Cpf, request.Name, request.Email);

            var repositorySignatary = _unitOfWork.GetRepository<Signatary>();

            repositorySignatary.Add(insertSignatary);

            await _unitOfWork.CommitAsync();

            return insertSignatary;
        }
    }
}
