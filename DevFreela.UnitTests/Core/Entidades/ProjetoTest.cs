using DevFreela.Core.Entidades;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DevFreela.UnitTests.Core.Entidades
{
    public class ProjetoTest
    {
        [Fact]
        public void TestarSeInicarProjetoFunciona()
        {
            var projeto = new Projeto("Nome teste", "Descricao teste", 1, 2, 10000);

            Assert.Equal(ProjetoStatusEnum.Criado, projeto.Status);
            Assert.Null(projeto.DataInicio);
            
            Assert.NotEmpty(projeto.Titulo);
            Assert.NotNull(projeto.Titulo);

            Assert.NotEmpty(projeto.Descricao);
            Assert.NotNull(projeto.Descricao);

            projeto.Iniciar();

            Assert.Equal(ProjetoStatusEnum.EmAndamento, projeto.Status);
            Assert.NotNull(projeto.DataInicio);           

        }
    }
}
