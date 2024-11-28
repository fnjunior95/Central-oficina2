using Ellp.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ellp.Api.Application.Interfaces;

namespace Ellp.Api.Infra.SqlServer.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(SqlServerDbContext context) : base(context)
        {
        }

        public async Task<Professor> GetAllProfessorInfosAsync(int professorId, string password)
        {
            var professor = await _context.Professors.FirstOrDefaultAsync(p => p.ProfessorId == professorId && p.Password == password);
            return professor;
        }
    }
}




