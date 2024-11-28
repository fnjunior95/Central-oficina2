﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ellp.Api.Application.UseCases.GetLoginUseCases.GetLoginStudent
{
    public class GetLoginStudentInput : IRequest<GetLoginStudentMapper>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}