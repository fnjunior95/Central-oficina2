using Ellp.Api.Domain.Entities;
using Ellp.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellp.Api.Infra.SqlServer.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(SqlServerDbContext context) : base(context)
        {
        }

        public async Task<Aluno> GetAllStudentInfosAsync(string email, string password)
        {
            var aluno = await _context.Students.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);

            return aluno;
        }
    }
}
