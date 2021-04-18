using DevFreela.Aplicacao.InputModels;
using DevFreela.Aplicacao.Servicos.Interfaces;
using DevFreela.Aplicacao.ViewModels;
using DevFreela.Core.Entidades;
using DevFreela.Infra.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Aplicacao.Servicos.Implementacoes
{
    public class ProjetoService : IProjetoService
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjetoService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Atualizar(AtualizarProjetoInputModel inputModel)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == inputModel.Id);

            projeto.Atualizar(inputModel.Titulo, inputModel.Descricao, inputModel.CustoTotal);
            _dbContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == id);
            projeto.Cancelar();

            _dbContext.SaveChanges();
        }

        public void Finalizar(int id)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == id);

            projeto.Finalizar();

            _dbContext.SaveChanges();
        }

        public void Iniciar(int id)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == id);

            projeto.Iniciar();
            _dbContext.SaveChanges();
        }

        public int Inserir(NovoProjetoInputModel inputModel)
        {
            var projeto = new Projeto(inputModel.Titulo, inputModel.Descricao, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.CustoTotal);
            _dbContext.Projetos.Add(projeto);
            _dbContext.SaveChanges();

            return projeto.Id;
        }

        public void InserirComentario(InserirComentarioInputModel inputmodel)
        {
            var comentario = new ComentarioProjeto(inputmodel.Conteudo, inputmodel.IdProjeto, inputmodel.IdUsuario);
            _dbContext.Comentarios.Add(comentario);

            _dbContext.SaveChanges();
        }

        public ProjetoDetalheViewModel Obter(int id)
        {
            var projeto = _dbContext.Projetos.SingleOrDefault(x => x.Id == id);
            var projetoDetailModel = new ProjetoDetalheViewModel(projeto.Id, projeto.Titulo, projeto.Descricao, projeto.CustoTotal, projeto.DataInicio, projeto.DataFinalizado);

            return projetoDetailModel;
        }

        public List<ProjetoViewModel> ObterTodos(string query)
        {
            var projetos = _dbContext.Projetos;
            var projetosModel = projetos
                .Select(x => new ProjetoViewModel(x.Id, x.Titulo, x.DataCriacao))
                .ToList();

            return projetosModel;
        }
    }
}
