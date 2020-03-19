using Domain.Leave.Entity.ValueObject;
using Interfaces.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Assembler
{
    public class ApproverAssembler
    {
        public static ApproverDTO ToDTO(Approver approver)
        {
            var dto = new ApproverDTO()
            {
                PersonId = approver.PersonId,
                PersonName = approver.PersonName
            };
            return dto;
        }
        public static Approver ToDO(ApproverDTO dto)
        {
            var approver = new Approver()
            {
                PersonId = dto.PersonId,
                PersonName = dto.PersonName
            };
            return approver;
        }
    }
}
