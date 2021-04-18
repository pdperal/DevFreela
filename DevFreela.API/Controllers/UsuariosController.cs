using DevFreela.API.Models;
using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController (IUsuarioService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _service.ObterUsuario(id);
            if(usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] InserirUsuarioInputModel criarUserModel)
        {
            var id = _service.Inserir(criarUserModel);

            return CreatedAtAction(nameof(ObterPorId), new { id = id }, criarUserModel);
        }

        [HttpPut("{id}/logar")]
        public IActionResult Login(int id, [FromBody] LogarModel logarModel)
        {
            return NoContent();
        }
    }
}
