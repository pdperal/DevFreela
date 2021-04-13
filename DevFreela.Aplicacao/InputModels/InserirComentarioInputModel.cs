using System;

namespace DevFreela.Aplicacao.InputModels
{
    public class InserirComentarioInputModel
    {
        public string Conteudo { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
    }
}