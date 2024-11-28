using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Ellp.Api.Application.Interfaces;

namespace Ellp.Api.Application.UseCases.LoginUsers
{
    public class GetLoginStudentUseCase : IRequestHandler<GetLoginStudentInput, GetLoginStudentMapper>
    {
        private readonly ILogger<GetLoginStudentUseCase> _logger;
        private readonly IAlunoRepository _studentRepository;

        public GetLoginStudentUseCase(ILogger<GetLoginStudentUseCase> logger, IAlunoRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        public async Task<GetLoginStudentMapper> Handle(GetLoginStudentInput request, CancellationToken cancellationToken)
        {
            try
            {
                var student = await _studentRepository.GetAllStudentInfosAsync(request.Email, request.Password);
                if (student == null || student.Senha != request.Password)
                {
                    return new GetLoginStudentMapper { Success = false, Message = "Invalid email or password" };
                }

                return GetLoginStudentMapper.ToLoginOutput(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return new GetLoginStudentMapper { Success = false, Message = "An error occurred" };
            }
        }
    }
}

