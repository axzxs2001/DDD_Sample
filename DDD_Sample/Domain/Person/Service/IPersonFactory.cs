using System;
using System.Collections.Generic;
using System.Text;
using Domain.Person.Entity;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.Persistence;
using Domain.Person.Repository.PO;

namespace Domain.Person.Service
{
    public interface IPersonFactory
    {
        PersonPO CreatePersonPO(Entity.Person person);

        Entity.Person CreatePerson(PersonPO po);

        Entity.Person GetPerson(PersonPO personPO);
    }
}
