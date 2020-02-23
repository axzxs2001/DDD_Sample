using Domain.Person.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Repository.Facade
{
    public interface IPersonRepository
    {
        void Insert(PersonPO personPO);

        void Update(PersonPO personPO);

        PersonPO FindById(String id);

        PersonPO FindLeaderByPersonId(String personId);
    }
}
