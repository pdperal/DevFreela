using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projetos")]
    public class ProjetosController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        public ProjetosController(IOptions<OpeningTimeOption> options)
        {
            _option = options.Value;
        }

        [HttpGet]
        public IActionResult Obter()
        {
            return Ok();
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
