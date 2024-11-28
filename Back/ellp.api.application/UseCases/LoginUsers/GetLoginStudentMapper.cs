using ellp.api.domain.entities;

namespace Ellp.Api.Application.UseCases.LoginUsers
{
    public class GetLoginStudentMapper
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        public static GetLoginStudentMapper ToLoginOutput(Aluno aluno)
        {
            return new GetLoginStudentMapper
            {
                Success = true,
                Message = "Login successful",
                StudentId = aluno.Id,
                Email = aluno.Email,
                Nome = aluno.Nome
            };
        }
    }
}

