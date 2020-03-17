using System;
using System.Collections.Generic;
using System.Text;
using Domain.Person.Entity;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.Persistence;
using Domain.Person.Repository.PO;
using Infrastructure.Util;

namespace Domain.Person.Service
{
    public class PersonFactory:IPersonFactory
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
            //补充信息
            personPO.DepartmentId = "dep001";//默认部门
            personPO.LeaderId = IdGenerator.NextId();
            return personPO;
        }

        public Entity.Person CreatePerson(PersonPO po)
        {
            var person = new Person.Entity.Person();
            person.PersonId = po.PersonId;
            person.PersonType = po.PersonType;
            person.RoleLevel = po.RoleLevel;
            person.PersonName = po.PersonName;
            person.Status = po.PersonStatus;
            person.CreateTime = po.CreateTime;
            person.LastModifyTime = po.LastModifyTime;
            return person;
        }

        public Entity.Person GetPerson(PersonPO personPO)
        {
            personPO = _personRepository.FindById(personPO.PersonId);
            return CreatePerson(personPO);
        }
    }
}
