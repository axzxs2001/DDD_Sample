using Domain.Person.Entity;
using Domain.Person.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IPersonApplicationService
    {     
        void Create(Person person);
        void Update(Person person);

        void DeleteById(string personId);

        Person FindById(string personId);

        Person FindFirstApprover(string applicantId, int leaderMaxLevel);

    }
}
