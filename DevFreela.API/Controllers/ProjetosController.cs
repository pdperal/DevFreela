using DevFreela.API.Models;
using DevFreela.Aplicacao.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projetos")]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        public ProjetosController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet]
        public IActionResult Obter(string query)
        {
            var projetos = _projetoService.ObterTodos(query);

            return Ok(projetos);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comentario")]
        public IActionResult InserirComentario(int id, [FromBody] InserirComentarioModel inserirComentarioModel)
        {
            return NoContent();
        }

        [HttpPut("{id}/iniciar")]
        public IActionResult Iniciar(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/finalizar")]
        public IActionResult Finalizar(int id)
        {
            return NoContent();
        }
    }
}
