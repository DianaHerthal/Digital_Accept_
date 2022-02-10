using Digital_Accept.Application.Signataries.Commands.CreateSignatary;
using Digital_Accept.Application.Signataries.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Accept.WebApi.Controllers
{
    public class SignatariesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetSignatariesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateSignataryCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
