using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OficinaELLP.Domain.Entities;
namespace OficinaELLP.Infra.Mysql{
    public class Context : DbContext
    {
        public Context(DbContextOptions<DbContext> options)
        : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}
