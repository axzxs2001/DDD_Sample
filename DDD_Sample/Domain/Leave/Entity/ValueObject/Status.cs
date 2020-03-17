using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    /// <summary>
    /// 请假状态
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 审批中
        /// </summary>
        APPROVING=0,
        /// <summary>
        /// 已审批
        /// </summary>
        APPROVED=1, 
        /// <summary>
        /// 拒绝
        /// </summary>
        REJECTED=2
    }
}
