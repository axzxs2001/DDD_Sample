using System;
using System.Collections.Generic;
using System.Text;
using Domain.Person.Entity;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.Persistence;
using Domain.Person.Repository.PO;

namespace Domain.Person.Service
{
    public class PersonFactory
    {
        readonly IPersonRepository _personRepository;
        public PersonFactory(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public PersonPO CreatePersonPO(Person.Entity.Person person)
        {
            var personPO = new PersonPO();
            personPO.PersonId = person.PersonId;
            personPO.PersonName = person.PersonName;
            personPO.RoleLevel = person.RoleLevel;
            personPO.PersonType = person.PersonType;
            personPO.CreateTime = person.CreateTime;
            personPO.LastModifyTime = person.LastModifyTime;
            return personPO;
        }

        public Person.Entity.Person CreatePerson(PersonPO po)
        {
            var person = new Person.Entity.Person();
            person.PersonId = po.PersonId;
            person.PersonType = po.PersonType;
            person.RoleLevel = po.RoleLevel;
            person.PersonName = po.PersonName;
            person.Status = po.Status;
            person.CreateTime = po.CreateTime;
            person.LastModifyTime = po.LastModifyTime;
            return person;
        }

        public Person.Entity.Person GetPerson(PersonPO personPO)
        {
            personPO = _personRepository.FindById(personPO.PersonId);
            return CreatePerson(personPO);
        }
    }
}
