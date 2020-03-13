using Domain.Leave.Entity.ValueObject;
using Interfaces.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Assembler
{
    public class ApplicantAssembler
    {
        public static ApplicantDTO ToDTO(Applicant applicant)
        {
            var dto = new ApplicantDTO()
            {
                PersonId = applicant.PersonId,
                PersonName = applicant.PersonName
            };
            return dto;
        }

        public static Applicant ToDO(ApplicantDTO dto)
        {
            var applicant = new Applicant()
            {
                PersonId = dto.getPersonId,
                PersonName = dto.getPersonName
            };
            return applicant;
        }
    }
}
