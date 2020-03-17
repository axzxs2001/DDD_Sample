using Domain.Person.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Repository.PO
{
    public class PersonPO
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string DepartmentId { get; set; }

        public PersonType PersonType { get; set; }

        public string LeaderId { get; set; }
        public int RoleLevel { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifyTime { get; set; }

        public PersonStatus PersonStatus { get; set; }

        public RelationshipPO RelationshipPO { get; set; }
    }
}
