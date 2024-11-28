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
    public class WorkshopAlunoConfiguration : IEntityTypeConfiguration<WorkshopAluno>
    {
        public void Configure(EntityTypeBuilder<WorkshopAluno> builder)
        {
            builder.ToTable("WorkshopAluno");

            builder.HasKey(wa => new { wa.WorkshopId, wa.AlunoId });

        }
    }
}
