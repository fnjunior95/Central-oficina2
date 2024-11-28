using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ellp.api.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellp.api.infra.sqlserver.Configurations
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Especialidade)
                .HasColumnName("Especialidade")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}

