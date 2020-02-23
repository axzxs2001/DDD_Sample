using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    public class Approver
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
    }
}
