using Domain.Leave.Entity;
using Interfaces.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Assembler
{
    public class LeaveAssembler
    {
        public static LeaveDTO ToDTO(Leave leave)
        {
            var approvalInfos = new List<ApprovalInfoDTO>();
            foreach (var historyApprovalInfo in leave.HistoryApprovalInfos)
            {
                approvalInfos.Add(ApprovalInfoAssembler.ToDTO(leave.CurrentApprovalInfo));
            }
            var dto = new LeaveDTO()
            {
                LeaveId = leave.Id,
                LeaveType = leave.Type.ToString(),
                Status = leave.Status.ToString(),
                StartTime = leave.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                EndTime = leave.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                CurrentApprovalInfoDTO = ApprovalInfoAssembler.ToDTO(leave.CurrentApprovalInfo),
                HistoryApprovalInfoDTOList = approvalInfos,
                Duration = leave.Duration
            };
            return dto;
        }

        public static Leave ToDO(LeaveDTO dto)
        {
            var historyApprovalInfoDTOList = new List<ApprovalInfo>();
            foreach (var historyApprovalInfoDTO in dto.HistoryApprovalInfoDTOList)
            {
                historyApprovalInfoDTOList.Add(ApprovalInfoAssembler.ToDO(historyApprovalInfoDTO));
            }
            var leave = new Leave()
            {
                Id = dto.LeaveId,
                Applicant = ApplicantAssembler.ToDO(dto.ApplicantDTO),
                Approver = ApproverAssembler.ToDO(dto.ApproverDTO),
                CurrentApprovalInfo = ApprovalInfoAssembler.ToDO(dto.CurrentApprovalInfoDTO),
                HistoryApprovalInfos = historyApprovalInfoDTOList
            };  
            return leave;
        }
    }
}
