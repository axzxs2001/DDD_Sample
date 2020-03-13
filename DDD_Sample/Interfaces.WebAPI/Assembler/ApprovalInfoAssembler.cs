using Domain.Leave.Entity;
using Interfaces.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Assembler
{
    public class ApprovalInfoAssembler
    {
        public static ApprovalInfo ToDO(ApprovalInfoDTO dto)
        {
            var approvalInfo = new ApprovalInfo()
            {
                ApprovalInfoId = dto.ApprovalInfoId,
                Msg = dto.Msg,
                Approver = ApproverAssembler.ToDO(dto.ApproverDTO)
            };
            return approvalInfo;
        }

        public static ApprovalInfoDTO ToDTO(ApprovalInfo approvalInfo)
        {
            var dto = new ApprovalInfoDTO()
            {
                ApprovalInfoId = approvalInfo.ApprovalInfoId,
                Msg = approvalInfo.Msg,
                Time = approvalInfo.Time
            };
            return dto;
        }
    }
}
