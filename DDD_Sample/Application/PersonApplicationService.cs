using Domain.Person.Entity;
using Domain.Person.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class PersonApplicationService : IPersonApplicationService
    {
        readonly IPersonDomainService _personDomainService;

        public PersonApplicationService(IPersonDomainService personDomainService)
        {
            _personDomainService = personDomainService;
        }
        public void Create(Person person)
        {
            _personDomainService.Create(person);
        }

        public void Update(Person person)
        {
            _personDomainService.Update(person);
        }

        public void DeleteById(string personId)
        {
            _personDomainService.DeleteById(personId);
        }

        public Person FindById(string personId)
        {
            return null;
        }

        public Person FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            return _personDomainService.FindFirstApprover(applicantId, leaderMaxLevel);
        }

    }
}
