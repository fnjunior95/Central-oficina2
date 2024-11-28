using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Ellp.Api.Application.UseCases.GetLoginUseCases.GetLoginProfessor;
using Ellp.Api.Application.UseCases.GetLoginUseCases.GetLoginStudent;

namespace Ellp.Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("login/student/{email}/{password}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLoginStudentMapper))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public async Task<IActionResult> GetLoginStudent([Required][FromRoute] string email, [Required][FromRoute] string password, CancellationToken cancellationToken)
        {
            try
            {
                var input = new GetLoginStudentInput { Email = email, Password = password };
                var result = await _mediator.Send(input, cancellationToken);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new Response { Message = result.Message });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = "An error occurred" });
            }
        }

        [HttpGet("login/professor/{professorId}/{password}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLoginProfessorMapper))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Response))]
        public async Task<IActionResult> GetLoginProfessor([Required][FromRoute] int professorId, [Required][FromRoute] string password, CancellationToken cancellationToken)
        {
            try
            {
                var input = new GetLoginProfessorInput { ProfessorId = professorId, Password = password };
                var result = await _mediator.Send(input, cancellationToken);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new Response { Message = result.Message });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = "An error occurred" });
            }
        }
    }

    public class Response
    {
        public string Message { get; set; }
    }
}

