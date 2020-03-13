using Domain.Leave.Entity;
using Domain.Leave.Entity.ValueObject;
using Domain.Leave.Service;
using Domain.Person.Service;
using Domain.Rule.Service;
using System;
using System.Collections.Generic;

namespace Application
{
    public interface ILeaveApplicationService
    {
        /**
         * 创建一个请假申请并为审批人生成任务
         * @param leave
         */
        void CreateLeaveInfo(Leave leave);

        /**
         * 更新请假单基本信息
         * @param leave
         */
        void UpdateLeaveInfo(Leave leave);

        /**
         * 提交审批，更新请假单信息
         * @param leave
         */
        void SubmitApproval(Leave leave);

        Leave GetLeaveInfo(string leaveId);
        List<Leave> QueryLeaveInfosByApplicant(string applicantId);

        List<Leave> QueryLeaveInfosByApprover(string approverId);
    }
}
