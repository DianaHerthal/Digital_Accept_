using Digital_Accept.Application.Documents.Commands.AddSignatary;
using Digital_Accept.Application.Documents.Commands.CreateDocument;
using Digital_Accept.Application.Documents.Commands.RefuseSignDocument;
using Digital_Accept.Application.Documents.Commands.SignDocument;
using Digital_Accept.Application.Documents.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Accept.WebApi.Controllers
{
    public class DocumentsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSync([FromQuery] GetDocumentsQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{documentId:long}")]
        public async Task<IActionResult> GetSync(long documentId)//[FromRoute] GetDocumentQuery query)
        {
            var query = new GetDocumentQuery() { DocumentId = documentId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        //[HttpGet("{documentId:long}")]
        //public async Task<IActionResult> GetSync([FromRoute]GetDocumentQuery query)
        //{           
        //    var result = await Mediator.Send(query);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateDocumentCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{documentId:long}/add-signatary")]
        public async Task<IActionResult> PutAddSignataryAsync(
            [FromRoute] long documentId,
            [FromBody] AddSignataryCommand command)
        {
            if (documentId != command.DocumentId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{documentId:long}/sign")]
        public async Task<IActionResult> PutAssinarAsync(
            [FromRoute] long documentId,
            [FromBody] SignDocumentCommand command)
        {
            if (documentId != command.DocumentId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{documentId:long}/refuse-signature")]
        public async Task<IActionResult> PutRefuseSignatureAsync(
            [FromRoute] long documentId,
            [FromBody] RefuseSignDocumentCommand command)
        {
            if (documentId != command.DocumentId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
