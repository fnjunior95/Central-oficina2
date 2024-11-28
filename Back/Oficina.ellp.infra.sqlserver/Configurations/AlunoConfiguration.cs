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
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

   

        }
    }
}
