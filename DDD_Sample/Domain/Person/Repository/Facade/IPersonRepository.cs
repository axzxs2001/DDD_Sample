using Domain.Person.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Repository.Facade
{
    public interface IPersonRepository
    {
        bool Insert(PersonPO personPO);

        bool Update(PersonPO personPO);

        PersonPO FindById(String id);

        PersonPO FindLeaderByPersonId(String personId);
    }
}
