using Domain.Person.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    /// <summary>
    /// 申请人
    /// </summary>
    public class Applicant : SeedWork.ValueObject
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// 人员类型 
        /// </summary>
        public PersonType PersonType { get; set; }
        /// <summary>
        /// 遍历属性
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { PersonId, PersonName, PersonType };
        }
    }
}
