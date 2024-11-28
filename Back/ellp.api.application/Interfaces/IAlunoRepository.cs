using ellp.api.domain.entities;
using System.Threading.Tasks;
using MediatR;

namespace Ellp.Api.Application.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> GetAllStudentInfosAsync(string email, string password);
    }
}
