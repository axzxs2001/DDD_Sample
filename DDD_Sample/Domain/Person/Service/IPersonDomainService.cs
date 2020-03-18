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

        void DeleteById(string personId);
        Entity.Person FindById(string personId);
    
        Entity.Person FindFirstApprover(string applicantId, int leaderMaxLevel);
        Entity.Person FindNextApprover(string currentApproverId, int leaderMaxLevel);

    }
}
