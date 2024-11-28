using System;
using System.Collections.Generic;

namespace ellp.api.domain.entities
{
    public class WorkshopAluno
    {
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
