using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WebAPI.DTO
{
    public class PersonDTO
    {
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public int RoleLevel { get; set; }
        public string PersonType { get; set; }
        public string CreateTime { get; set; }
        public string LastModifyTime { get; set; }
        public string Status { get; set; }
    }
}
