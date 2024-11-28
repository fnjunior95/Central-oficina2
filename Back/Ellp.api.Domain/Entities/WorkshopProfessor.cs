using System;
using System.Collections.Generic;

namespace ellp.api.domain.entities
{
    public class WorkshopProfessor
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}
