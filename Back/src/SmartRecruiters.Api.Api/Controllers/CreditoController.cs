using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartRecruiters.Api.Application.Commands.AppCredito;

namespace SmartRecruiters.Api.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CreditoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("integrar-credito-constituido")]
        [ProducesResponseType(typeof(bool), 202)]
        public async Task<IActionResult> PostCreateCredito(
            [FromBody] CreateCreditoCommandCollection command
        )
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return Accepted(result.Data);
        }

        [HttpGet("credito/{numeroCredito}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> GetCreditoNumeroCredito(string numeroCredito)
        {
            var command = new GetCreditoNumeroCreditoQuery()
            {
                numeroCredito = numeroCredito
            };

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return new OkObjectResult(result.Data);
        }

        [HttpGet("creditos/{numeroNfes}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> GetCreditoNumeroNfs(string numeroNfes)
        {
            var query = new GetCreditoNumeroNfseQuery()
            {
                NumeroNfse = numeroNfes
            };

            var result = await _mediator.Send(query);

            if (!result.Success)
            {
                return new BadRequestObjectResult(result.Data);
            }
            return new OkObjectResult(result.Data);
        }
    }
}