using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requisition.DataAccess.EntityDTO;
namespace Requisition.Services.Interfaces
{
    public interface IReqInfoService
    {
       Task<bool> AddRequisition(RequisitionRecordDTO requisitionRecordDTO);
       List<RequisitionRecordDTO> GetRequisition();
    }
}
