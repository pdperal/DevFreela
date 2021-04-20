using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; set; }
        public List<HabilidadeUsuario> Habilidades { get; private set; }
        public List<Projeto> ProjetosPublicados { get; private set; }
        public List<Projeto> ProjetosFreelancer { get; private set; }
        public List<ComentarioProjeto> Comentarios { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }

        public Usuario(string nomeCompleto, string email, DateTime dataNascimento, string senha, string role)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Habilidades = new List<HabilidadeUsuario>();
            ProjetosPublicados = new List<Projeto>();
            ProjetosFreelancer = new List<Projeto>();
            Ativo = true;
            Senha = senha;
            Role = role;
        }
    }
}
