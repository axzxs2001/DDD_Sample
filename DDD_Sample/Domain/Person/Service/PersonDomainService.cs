using Domain.Person.Repository.Facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Service
{
    public class PersonDomainService : IPersonDomainService
    {

        readonly IPersonRepository _personRepository;
        readonly PersonFactory _personFactory;
        public PersonDomainService(IPersonRepository personRepository, PersonFactory personFactory)
        {
            _personRepository = personRepository;
            _personFactory = personFactory;
        }


        public void Create(Entity.Person person)
        {
            var personPO = _personRepository.FindById(person.PersonId);
            if (null != personPO)
            {
                throw new Exception("Person already exists");
            }
            person.Create();
            _personRepository.Insert(_personFactory.CreatePersonPO(person));
        }

        public void Update(Entity.Person person)
        {
            person.LastModifyTime = DateTime.Now;
            _personRepository.Update(_personFactory.CreatePersonPO(person));
        }

        public void DeleteById(String personId)
        {
            var personPO = _personRepository.FindById(personId);
            var person = _personFactory.GetPerson(personPO);
            person.disable();
            _personRepository.Update(_personFactory.CreatePersonPO(person));
        }

        public Entity.Person FindById(String userId)
        {
            var personPO = _personRepository.FindById(userId);
            return _personFactory.GetPerson(personPO);
        }

        /**
         * find leader with applicant, if leader level bigger then leaderMaxLevel return null, else return Approver from leader;
         *
         * @param applicantId
         * @param leaderMaxLevel
         * @return
         */
        public Entity.Person FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            var leaderPO = _personRepository.FindLeaderByPersonId(applicantId);
            if (leaderPO.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return _personFactory.CreatePerson(leaderPO);
            }
        }

        /**
         * find leader with current approver, if leader level bigger then leaderMaxLevel return null, else return Approver from leader;
         *
         * @param currentApproverId
         * @param leaderMaxLevel
         * @return
         */
        public Entity.Person FindNextApprover(String currentApproverId, int leaderMaxLevel)
        {
            var leaderPO = _personRepository.FindLeaderByPersonId(currentApproverId);
            if (leaderPO.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return _personFactory.CreatePerson(leaderPO);
            }
        }
    }
}
