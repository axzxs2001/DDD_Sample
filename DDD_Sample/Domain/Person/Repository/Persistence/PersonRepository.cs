using Dapper;
using Domain.Person.Repository.Facade;
using Domain.Person.Repository.PO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Domain.Person.Repository.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        readonly ILogger<PersonRepository> _logge;
        readonly IDbConnection _db;
        public PersonRepository(IDbConnection db, ILogger<PersonRepository> logger)
        {
            _logge = logger;
            _db = db;
        }

        public PersonPO FindById(string id)
        {

            try
            {
                var sql = @"SELECT personid, personname, departmentid, persontype, leaderid, rolelevel, createtime, lastmodifytime, personstatus
	FROM public.persons where personid=@personid;";
                return _db.Query<PersonPO>(sql, new { personid = id }).SingleOrDefault();

            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return null;
            }

        }

        public PersonPO FindLeaderByPersonId(string personId)
        {
            try
            {
                var sql = @"
select p.personid, p.personname, p.departmentid, p.persontype, p.leaderid, p.rolelevel, p.createtime, p.lastmodifytime, p.personstatus from persons p join relation_ships rs on p.leaderid=rs.leaderid where 
rs.personid=@personid";
                return _db.Query<PersonPO>(sql, new { personid = personId }).SingleOrDefault();
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return null;
            }

        }

        public bool Insert(PersonPO personPO)
        {

            try
            {
                var sql = @"INSERT INTO public.persons(
	personid, personname, departmentid, persontype, leaderid, rolelevel, createtime, lastmodifytime, personstatus)
	VALUES (@personid, @personname, @departmentid, @persontype, @leaderid, @rolelevel, @createtime, @lastmodifytime, @personstatus);";
                _db.Execute(sql, personPO);
                return true;
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return false;
            }


        }

        public bool Update(PersonPO personPO)
        {

            try
            {
                var sql = @"UPDATE public.persons
	SET personname=@personname, departmentid=@departmentid, persontype=@persontype, leaderid=@leaderid, rolelevel=@rolelevel, createtime=@createtime, lastmodifytime=@lastmodifytime, personstatus=@personstatus
	WHERE personid=@personid;";
                _db.Execute(sql, personPO);
                return true;
            }
            catch (Exception exc)
            {
                _logge.LogCritical(exc, exc.Message);
                return false;
            }

        }
    }
}
