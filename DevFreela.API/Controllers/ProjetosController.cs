using DevFreela.Aplicacao.Commands.AtualizarProjeto;
using DevFreela.Aplicacao.Commands.FinalizarProjeto;
using DevFreela.Aplicacao.Commands.IniciarProjeto;
using DevFreela.Aplicacao.Commands.Inserir;
using DevFreela.Aplicacao.Commands.InserirComentario;
using DevFreela.Aplicacao.Commands.RemoverProjeto;
using DevFreela.Aplicacao.Queries.ObterProjeto;
using DevFreela.Aplicacao.Queries.ObterTodosProjetos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projetos")]
    [Authorize]
    public class ProjetosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjetosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "freelancer, client")]
        public async Task<IActionResult> Obter(string query)
        {
            var queryInstancia = new ObterTodosProjetosQuery(query);

            var projetos = await _mediator.Send(queryInstancia);

            return Ok(projetos);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "freelancer, client")]
        public async Task<IActionResult> ObterProjeto(int id)
        {
            var query = new ObterProjetoQuery(id);

            var projeto = await _mediator.Send(query);
            if (projeto == null)
            {
                return NotFound();
            }
            return Ok(projeto);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Inserir([FromBody] InserirProjetoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ObterProjeto), new { id }, command);
        }

        [HttpPut]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarProjetoCommand command)
        {
            if (command.Descricao.Length > 200)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Deletar(int id)
        {
            var command = new DeletarProjetoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comentario")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> InserirComentario(int id, [FromBody] InserirComentarioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/iniciar")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Iniciar(int id)
        {
            var command = new IniciarProjetoCommand(id);

            await _mediator.Send(command);            

            return NoContent();
        }

        [HttpPut("{id}/finalizar")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finalizar(int id)
        {
            var command = new FinalizarProjetoCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
