using DevFreela.API.Models;
using DevFreela.Aplicacao.Commands.InserirUsuario;
using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.Queries.ObterUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuariosController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Obter(int id)
        {
            var query = new ObterUsuarioQuery(id);
            var usuario = await _mediator.Send(query);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Obter), new { id = id }, command);
        }

        [HttpPut("{id}/logar")]
        public IActionResult Login(int id, [FromBody] LogarModel logarModel)
        {
            return NoContent();
        }
    }
}
