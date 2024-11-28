using Microsoft.EntityFrameworkCore;
using ellp.api.domain.entities;
using Ellp.api.infra.sqlserver.Configurations;

namespace ellp.api.infra.sqlserver
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<WorkshopAluno> WorkshopAlunos { get; set; }
        public DbSet<WorkshopProfessor> WorkshopProfessors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new WorkshopConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkshopAlunoConfiguration());
            modelBuilder.ApplyConfiguration(new WorkshopProfessorConfiguration());
        }
    }
}
