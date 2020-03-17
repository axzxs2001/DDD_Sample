using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity.ValueObject
{
    /// <summary>
    ///批准人 
    /// </summary>
    public class Approver : SeedWork.ValueObject
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
        /// 级别
        /// </summary>
        public int Level { set; get; }
        /// <summary>
        /// 从人员转换成申请人
        /// </summary>
        /// <param name="person">人员实体</param>
        /// <returns></returns>
        public static Approver FromPerson(Person.Entity.Person person)
        {
            var approver = new Approver();
            approver.PersonId = person.PersonId;
            approver.PersonName = person.PersonName;
            approver.Level = person.RoleLevel;
            return approver;
        }
        /// <summary>
        /// 遍历属性
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return new object[] { PersonId, PersonName, Level };
        }
    }
}
