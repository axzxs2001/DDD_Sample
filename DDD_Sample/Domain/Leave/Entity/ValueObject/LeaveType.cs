using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    /// <summary>
    /// 假条类型
    /// </summary>
    public enum LeaveType
    {
        /// <summary>
        /// 内部
        /// </summary>
        Internal,
        /// <summary>
        /// 外部
        /// </summary>
        External,
        /// <summary>
        /// 官方
        /// </summary>
        Official
    }
}
