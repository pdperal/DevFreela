using DevFreela.API.Models;
using DevFreela.Aplicacao.InputModels;
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

        [HttpGet("{id}")]
        public IActionResult ObterProjeto(int id)
        {
            var projetos = _projetoService.Obter(id);
            if (projetos == null)
            {
                return NotFound();
            }
            return Ok(projetos);
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] InserirProjetoInputModel model)
        {
            if (model.Titulo.Length > 50)
            {
                return BadRequest();
            }

            var id = _projetoService.Inserir(model);

            return CreatedAtAction(nameof(ObterProjeto), new { id }, model);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] AtualizarProjetoInputModel model)
        {
            if (model.Descricao.Length > 200)
            {
                return BadRequest();
            }

            _projetoService.Atualizar(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _projetoService.Deletar(id);

            return NoContent();
        }

        [HttpPost("{id}/comentario")]
        public IActionResult InserirComentario(int id, [FromBody] InserirComentarioInputModel inserirComentarioModel)
        {
            _projetoService.InserirComentario(inserirComentarioModel);

            return NoContent();
        }

        [HttpPut("{id}/iniciar")]
        public IActionResult Iniciar(int id)
        {
            _projetoService.Iniciar(id);

            return NoContent();
        }

        [HttpPut("{id}/finalizar")]
        public IActionResult Finalizar(int id)
        {
            _projetoService.Finalizar(id);
            return NoContent();
        }
    }
}
