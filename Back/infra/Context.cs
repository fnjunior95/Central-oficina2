using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;  
using OficinaELLP.Domain.Entities;

namespace OficinaELLP.Infra.SqlServer
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(DbContextOptions<Context> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("MyDbConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
