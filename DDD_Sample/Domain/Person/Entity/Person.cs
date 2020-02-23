using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Entity
{
    public class Person
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public PersonType PersonType { get; set; }
        public List<Relationship> Relationships { get; set; }
        public int RoleLevel { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastModifyTime { get; set; }
        public PersonStatus Status { get; set; }

        public Person create()
        {
            this.CreateTime = DateTime.Now;
            this.Status = PersonStatus.ENABLE;
            return this;
        }

        public Person enable()
        {
            this.LastModifyTime = DateTime.Now;
            this.Status = PersonStatus.ENABLE;
            return this;
        }

        public Person disable()
        {
            this.LastModifyTime = DateTime.Now;
            this.Status = PersonStatus.DISABLE;
            return this;
        }
    }
}
