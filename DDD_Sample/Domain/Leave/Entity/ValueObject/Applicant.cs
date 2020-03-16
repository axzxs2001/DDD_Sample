using Domain.Person.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    public class Applicant : SeedWork.ValueObject
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public PersonType PersonType { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { PersonId, PersonName, PersonType };
        }
    }
}
