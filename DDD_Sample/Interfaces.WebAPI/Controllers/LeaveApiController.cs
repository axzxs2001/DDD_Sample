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
        readonly ILogger<LeaveApiController> _logger;
        readonly ILeaveApplicationService _leaveApplicationService;
        public LeaveApiController(ILeaveApplicationService leaveApplicationService,ILogger<LeaveApiController> logger)
        {
            _logger = logger;
            _leaveApplicationService = leaveApplicationService;
        }
        [HttpPost("/leave")]
        public IActionResult CreateLeaveInfo([FromBody]LeaveDTO leaveDTO)
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
        /// <summary>
        /// 根据请假ID查询请假事项
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        [HttpGet("/{leaveId}")]
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
        [HttpGet("/query/applicant/{applicantId}")]
        public IActionResult QueryByApplicant(string applicantId)
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
        [HttpGet("/query/approver/{approverId}")]
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
