using DevFreela.Core.Entidades;
using System;
using System.Collections.Generic;

namespace DevFreela.Infra.Persistencia
{
    public class DevFreelaDbContext
    {
        public List<Projeto> Projetos { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Habilidade> Habilidades{ get; set; }
        public List<ComentarioProjeto> Comentarios { get; set; }

        public DevFreelaDbContext()
        {
            Projetos = new List<Projeto>
            {
                new Projeto("Projeto ASP.NET Core 1.", "Descrição do projeto 1.", 1, 1, 10000),
                new Projeto("Projeto ASP.NET Core 2.", "Descrição do projeto 2.", 1, 1, 20000),
                new Projeto("Projeto ASP.NET Core 3.", "Descrição do projeto 3.", 1, 1, 30000)
            };
            Usuarios = new List<Usuario>
            {
                new Usuario("Pedro", "pedro@gmail.com", new DateTime(1950, 1, 1)),
                new Usuario("Julia", "julia@gmail.com", new DateTime(1960, 1, 1)),
                new Usuario("Rodrigo", "Rodrigo@gmail.com", new DateTime(1970, 1, 1)),
            };
            Habilidades = new List<Habilidade>
            {
                new Habilidade(".NET Core"),
                new Habilidade("C#"),
                new Habilidade("SQL Server")
            };            
        }
    }
}
