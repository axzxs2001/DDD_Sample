using Domain.Leave.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity
{
    /// <summary>
    /// 批准信息
    /// </summary>
    public class ApprovalInfo
    {
        /// <summary>
        /// 批准信息ID
        /// </summary>
        public string ApprovalInfoId { get; set; }
        /// <summary>
        /// 批准人
        /// </summary>
        public Approver Approver { get; set; }
        /// <summary>
        /// 批准类型
        /// </summary>
        public ApprovalType ApprovalType { get; set; }
        /// <summary>
        /// 批准信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 这个是什么？
        /// </summary>
        public long Time { get; set; }
    }
}
