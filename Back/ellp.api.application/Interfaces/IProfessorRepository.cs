using Ellp.Api.Application.Interfaces;
using Ellp.Api.Domain.Entities;


public interface IProfessorRepository : IRepository<Professor>
{
    Task<Professor> GetAllProfessorInfosAsync(int professorId, string password);
}
