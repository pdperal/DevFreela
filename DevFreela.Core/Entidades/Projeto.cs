﻿using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entidades
{
    public class Projeto : EntidadeBase
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int IdCliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal CustoTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataInicio { get; private set; }
        public DateTime DataFinalizado { get; private set; }
        public ProjetoStatusEnum Status { get; private set; }
        public List<ComentarioProjeto> Comentarios { get; private set; }

        public Projeto(string titulo, string descricao, int idCliente, int idFreelancer, decimal custoTotal)
        {
            Titulo = titulo;
            Descricao = descricao;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            CustoTotal = custoTotal;
            DataCriacao = DateTime.Now;
            Status = ProjetoStatusEnum.Criado;
            Comentarios = new List<ComentarioProjeto>();
        }
    }
}