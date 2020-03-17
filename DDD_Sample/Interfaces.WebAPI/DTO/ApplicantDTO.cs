using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WebAPI.DTO
{
    public class ApplicantDTO
    {

        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public string LeaderId { get; set; }
        public string ApplicantType { get; set; }
        public int RoleLevel { get; set; }
    }
}
