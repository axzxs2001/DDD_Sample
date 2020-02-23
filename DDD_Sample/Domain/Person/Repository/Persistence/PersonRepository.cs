using Domain.Person.Repository.Facade;
using Domain.Person.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Person.Repository.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        public PersonPO FindById(string id)
        {
            throw new NotImplementedException();
        }

        public PersonPO FindLeaderByPersonId(string personId)
        {
            throw new NotImplementedException();
        }

        public void Insert(PersonPO personPO)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonPO personPO)
        {
            throw new NotImplementedException();
        }
    }
}
