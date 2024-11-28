using System;
using System.Collections.Generic;

namespace ellp.api.domain.entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }
}
