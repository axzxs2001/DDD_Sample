using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
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
