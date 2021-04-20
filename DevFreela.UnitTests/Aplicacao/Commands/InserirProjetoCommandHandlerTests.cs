using DevFreela.Aplicacao.Commands.Inserir;
using DevFreela.Aplicacao.Commands.InserirProjeto;
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

namespace DevFreela.UnitTests.Aplicacao.Commands
{
    public class InserirProjetoCommandHandlerTests
    {
        [Fact]

        public async Task DadosParaInsercaoOK_Executado_RetornaIdProjeto()
        {
            // Arrange
            var projetoRepositoryMock = new Mock<IProjetoRepository>();
            var inserirProjetoCommand = new InserirProjetoCommand()
            {
                Titulo = "Titulo teste",
                Descricao = "Descricao teste",
                CustoTotal = 2000,
                IdCliente = 1,
                IdFreelancer = 2
            };

            var inserirProjetoCommandHandler = new InserirProjetoCommandHandler(projetoRepositoryMock.Object);

            // Act

            var id = await inserirProjetoCommandHandler.Handle(inserirProjetoCommand, new CancellationToken());

            // Assert

            Assert.True(id >= 0);
            projetoRepositoryMock.Verify(pr => pr.InserirAsync(It.IsAny<Projeto>()), Times.Once);
        }
    }
}
