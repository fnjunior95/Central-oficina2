using Microsoft.EntityFrameworkCore;
using SSE.Oficina.Domain.Entities;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Professor> Professores { get; set; }
}