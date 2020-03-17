using Domain.Person.Entity;
using Interfaces.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Assembler
{
    public class PersonAssembler
    {
        public static PersonDTO ToDTO(Person person)
        {
            var dto = new PersonDTO()
            {
                PersonId = person.PersonId,
                PersonType = person.PersonType.ToString(),
                PersonName = person.PersonName,
                Status = person.Status.ToString(),
                CreateTime = person.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                LastModifyTime = person.LastModifyTime.ToString("yyyy-MM-dd HH:mm:ss")
            };
            return dto;
        }

        public static Person ToDO(PersonDTO dto)
        {
            var person = new Person()
            {
                PersonId = dto.PersonId,
                PersonType = (PersonType)Enum.Parse(typeof(PersonType), dto.PersonType),
                PersonName = dto.PersonName,
                RoleLevel=dto.RoleLevel,
                Status = (PersonStatus)Enum.Parse(typeof(PersonStatus), dto.Status),
                CreateTime = string.IsNullOrEmpty(dto.CreateTime) ? DateTime.Now : Convert.ToDateTime(dto.CreateTime),
                LastModifyTime = string.IsNullOrEmpty(dto.LastModifyTime) ? DateTime.Now : Convert.ToDateTime(dto.LastModifyTime)
            };
            return person;
        }
    }
}
