using Domain.Leave.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WebAPI.DTO
{
    public class ApprovalInfoDTO
    {
        public string ApprovalInfoId { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public ApproverDTO ApproverDTO { get; set; }
        public string Msg { get; set; }
        public long Time { get; set; }
    }
}
