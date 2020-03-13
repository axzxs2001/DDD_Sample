using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Interfaces.WebAPI.Assembler;
using Interfaces.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interfaces.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveApiController : ControllerBase
    {
        readonly ILeaveApplicationService _leaveApplicationService;
        public LeaveApiController(ILeaveApplicationService leaveApplicationService)
        {
            _leaveApplicationService = leaveApplicationService;
        }
        [HttpPost]
        public IActionResult CreateLeaveInfo(LeaveDTO leaveDTO)
        {
            var leave = LeaveAssembler.ToDO(leaveDTO);
            _leaveApplicationService.CreateLeaveInfo(leave);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateLeaveInfo(LeaveDTO leaveDTO)
        {
            var leave = LeaveAssembler.ToDO(leaveDTO);
            _leaveApplicationService.UpdateLeaveInfo(leave);
            return Ok();
        }

        [HttpPost("/submit")]
        public IActionResult SubmitApproval(LeaveDTO leaveDTO)
        {
            var leave = LeaveAssembler.ToDO(leaveDTO);
            _leaveApplicationService.SubmitApproval(leave);
            return Ok();
        }

        [HttpPost("/{leaveId}")]
        public IActionResult FindById(string leaveId)
        {
            var leave = _leaveApplicationService.GetLeaveInfo(leaveId);
            return Ok(LeaveAssembler.ToDTO(leave));
        }

        /**
         * 根据申请人查询所有请假单
         * @param applicantId
         * @return
         */
        [HttpPost("/query/applicant/{applicantId}")]
        public IActionResult queryByApplicant(string applicantId)
        {
            var leaveList = _leaveApplicationService.QueryLeaveInfosByApplicant(applicantId);
            var leaveDTOList = new List<LeaveDTO>();
            foreach (var leave in leaveList)
            {
                leaveDTOList.Add(LeaveAssembler.ToDTO(leave));
            };
            return Ok(leaveDTOList);
        }

        /**
         * 根据审批人id查询待审批请假单（待办任务）
         * @param approverId
         * @return
         */
        [HttpPost("/query/approver/{approverId}")]
        public IActionResult QueryByApprover(string approverId)
        {
            var leaveList = _leaveApplicationService.QueryLeaveInfosByApprover(approverId);
            var leaveDTOList = new List<LeaveDTO>();
            foreach (var leave in leaveList)
            {
                leaveDTOList.Add(LeaveAssembler.ToDTO(leave));
            };
            return Ok(leaveDTOList);
        }
    }
}
