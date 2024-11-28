using Ellp.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ellp.Api.Infra.SqlServer.Configurations
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

            builder.Property(x => x.Password)
                .HasColumnName("Senha")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.BirthDate)
                .HasColumnName("DataNascimento")
                .IsRequired();

   

        }
    }
}
