using DevFreela.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infra.Persistencia.Configuracoes
{
    public class HabilidadeConfiguracoes : IEntityTypeConfiguration<Habilidade>
    {
        public void Configure(EntityTypeBuilder<Habilidade> builder)
        {

            builder
                .HasKey(prop => prop.Id);
        }
    }
}
