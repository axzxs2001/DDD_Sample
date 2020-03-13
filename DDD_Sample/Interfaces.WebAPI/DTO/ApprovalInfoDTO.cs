using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WebAPI.DTO
{
    public class ApprovalInfoDTO
    {
        public string ApprovalInfoId { get; set; }
        public ApproverDTO ApproverDTO { get; set; }
        public string Msg { get; set; }
        public double Time { get; set; }
    }
}
