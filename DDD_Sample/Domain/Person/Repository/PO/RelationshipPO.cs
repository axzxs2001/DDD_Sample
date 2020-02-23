using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Repository.PO
{
    public class RelationshipPO
    {
        public string Id;
        public string PersonId { get; set; }
        public string LeaderId { get; set; }
    }
}
