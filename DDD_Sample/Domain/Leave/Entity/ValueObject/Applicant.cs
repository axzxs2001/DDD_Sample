using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    public class Applicant
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonType { get; set; }
    }
}
