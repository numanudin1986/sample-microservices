using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requisition.DataAccess.EntityDTO
{
    public class RequisitionRecordDTO
    {
        public string? TestName { get; set; }
        public string? SpecimenType { get; set; }
        public int? FacilityId { get; set; }
        public int? PatientId { get; set; }

    }
}
