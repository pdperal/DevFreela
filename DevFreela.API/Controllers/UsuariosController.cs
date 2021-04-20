using DevFreela.Aplicacao.Commands.InserirUsuario;
using DevFreela.Aplicacao.Commands.LoginUsuario;
using DevFreela.Aplicacao.Queries.ObterUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/usuarios")]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Inserir([FromBody] InserirUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Obter), new { id = id }, command);
        }

        [HttpPut("logar")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand logarModel)
        {
            var loginModel = await _mediator.Send(logarModel);
            if (loginModel == null)
            {
                return BadRequest();
            }

            return Ok(loginModel);
        }
    }
}
