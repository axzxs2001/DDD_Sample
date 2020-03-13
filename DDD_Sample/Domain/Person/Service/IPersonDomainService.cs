using Domain.Person.Repository.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Service
{
    public interface IPersonDomainService
    {
        void Create(Entity.Person person);
        void Update(Entity.Person person);

        void DeleteById(String personId);
        Entity.Person FindById(String userId);
        /**
         * find leader with applicant, if leader level bigger then leaderMaxLevel return null, else return Approver from leader;
         *
         * @param applicantId
         * @param leaderMaxLevel
         * @return
         */
        Entity.Person FindFirstApprover(string applicantId, int leaderMaxLevel);

        /**
         * find leader with current approver, if leader level bigger then leaderMaxLevel return null, else return Approver from leader;
         *
         * @param currentApproverId
         * @param leaderMaxLevel
         * @return
         */
        Entity.Person FindNextApprover(String currentApproverId, int leaderMaxLevel);

    }
}
