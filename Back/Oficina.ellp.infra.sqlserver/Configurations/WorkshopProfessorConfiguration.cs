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
    public class WorkshopProfessorConfiguration : IEntityTypeConfiguration<WorkshopProfessor>
    {
        public void Configure(EntityTypeBuilder<WorkshopProfessor> builder)
        {
            builder.ToTable("ProfessorWorkshop");

            builder.HasKey(pw => new { pw.ProfessorId, pw.WorkshopId });

            builder.HasOne(pw => pw.Professor);

        }
    }
}
