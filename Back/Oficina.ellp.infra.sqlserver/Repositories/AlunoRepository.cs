using ellp.api.domain.entities;
using ellp.api.infra.sqlserver;
using Ellp.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ellp.Api.Infra.SqlServer.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SqlServerDbContext context) : base(context)
        {
        }

        public async Task<Aluno> GetAllStudentInfosAsync(string email, string password)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Email == email && a.Senha == password);

            if (aluno != null)
            {
                return new Aluno
                {
                    Id = aluno.Id,
                    Email = aluno.Email,
                    Nome = aluno.Nome // Supondo que a classe Aluno tenha uma propriedade Nome
                };
            }

            return null;
        }
    }
}
