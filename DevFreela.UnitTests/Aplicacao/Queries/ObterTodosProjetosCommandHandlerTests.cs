using DevFreela.Aplicacao.Queries.ObterTodosProjetos;
using DevFreela.Core.Entidades;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Aplicacao.Queries
{
    public class ObterTodosProjetosCommandHandlerTests
    {
        [Fact]
        public async Task TresProjetosExistem_Executado_RetornarTresProjetosViewModel()
        {
            // Arrange
            var projetos = new List<Projeto>
            {
                new Projeto("Projeto teste 1", "Descricao teste 1", 1, 2, 1000),
                new Projeto("Projeto teste 2", "Descricao teste 2", 1, 2, 2000),
                new Projeto("Projeto teste 3", "Descricao teste 3", 1, 2, 3000),
            };

            var projetoRepositoryMock = new Mock<IProjetoRepository>();
            projetoRepositoryMock.Setup(pr => pr.ObterTodosAsync().Result).Returns(projetos);

            var obterTodosProjetosQuery = new ObterTodosProjetosQuery("");
            var obterTodosProjetosQueryHandler = new ObterTodosProjetosQueryHandler(projetoRepositoryMock.Object);
            // Act

            var projetoViewModelList = await obterTodosProjetosQueryHandler.Handle(obterTodosProjetosQuery, new CancellationToken());

            // Assert

            Assert.NotNull(projetoViewModelList);
            Assert.NotEmpty(projetoViewModelList);
            Assert.Equal(projetos.Count, projetoViewModelList.Count);

            projetoRepositoryMock.Verify(pr => pr.ObterTodosAsync().Result, Times.Once);
        }
    }
}
