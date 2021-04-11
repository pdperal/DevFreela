using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] CriarUserModel criarUserModel)
        {
            return CreatedAtAction(nameof(ObterPorId), new { id = 1 }, criarUserModel);
        }

        [HttpPut("{id}/logar")]
        public IActionResult Login(int id, [FromBody] LogarModel logarModel)
        {
            return NoContent();
        }
    }
}
