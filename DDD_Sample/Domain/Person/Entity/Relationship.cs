using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Entity
{
    public class Relationship
    {
        public string Id { set; get; }
        public string PersonId { get; set; }
        public string LeaderId { get; set; }
        public int LeaderLevel { get; set; }
    }
}
