using Digital_Accept.Domain.Entities;
using Digital_Accept.Domain.Interfaces.Infraestructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Application.Documents.Queries
{
    public class GetDocumentsQuery : IRequest<List<Document>>
    {
        public string? SearchTerm { get; set; }

        public bool OnlySignatureFinalized { get; set; }
    }

    public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, List<Document>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDocumentsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Document>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var repositoryDocument = _unitOfWork.GetRepository<Document>();

            //cria um filtro informando que deve buscar todos os documentos
            var documentQuery = repositoryDocument.GetAll();

            //verifica se deve filtrar somente os documentos com todas as assinaturas aceitas.
            if (request.OnlySignatureFinalized)
            {
                //cria o filtro para buscar somente os documentos que tenham todas as assinaturas aceitas
                documentQuery = documentQuery.Where(
                    d => d.SignatariesDocuments.All(a => a.Signature.Accept && a.Signature != null));
            }

            //verifica se foi informado filtro por termo
            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                ///cria o filtro para buscar se o campo de descrição ou título contem o termo informado para filtro
                documentQuery = documentQuery.Where(
                    d => d.Description.Contains(request.SearchTerm) ||
                        d.Title.Contains(request.SearchTerm));
            }

            //executa de fato a consulta
            var documents = await documentQuery
                .ToListAsync(cancellationToken);

            return documents;
        }
    }
}
