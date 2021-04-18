using DevFreela.Aplicacao.Queries.ObterTodasHabilidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/habilidades")]
    public class HabilidadesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HabilidadesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var query = new ObterTodasHabilidadesQuery();
            var habilidades = await _mediator.Send(query);

            return Ok(habilidades);
        }
    }
}
