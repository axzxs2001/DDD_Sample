using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    /// <summary>
    ///批准人 
    /// </summary>
    public class Approver : SeedWork.ValueObject
    {
       
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public int Level { set; get; }

        public static Approver FromPerson(Person.Entity.Person person)
        {
            var approver = new Approver();
            approver.PersonId = person.PersonId;
            approver.PersonName = person.PersonName;
            approver.Level = person.RoleLevel;
            return approver;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { PersonId, PersonName, Level };
        }
    }
}
