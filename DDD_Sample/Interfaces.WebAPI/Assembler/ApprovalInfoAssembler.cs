using Domain.Leave.Entity;
using Domain.Leave.Entity.ValueObject;
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
            if (dto == null)
            {
                return null;
            }
            var approvalInfo = new ApprovalInfo()
            {
                ApprovalType = dto.ApprovalType,
                Time = dto.Time,
                ApprovalInfoId = dto.ApprovalInfoId,
                Msg = dto.Msg,
                Approver = ApproverAssembler.ToDO(dto.ApproverDTO)
            };
            return approvalInfo;
        }

        public static ApprovalInfoDTO ToDTO(ApprovalInfo approvalInfo)
        {
            if (approvalInfo == null)
            {
                return null;
            }
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
