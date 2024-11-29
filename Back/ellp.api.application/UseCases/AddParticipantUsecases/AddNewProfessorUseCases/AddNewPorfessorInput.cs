using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ellp.Api.Application.UseCases.AddParticipantUsecases.AddNewProfessorUseCases
{
    public class AddNewProfessorInput : IRequest<AddNewProfessorMapper>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Specialty { get; set; }
    }
}

