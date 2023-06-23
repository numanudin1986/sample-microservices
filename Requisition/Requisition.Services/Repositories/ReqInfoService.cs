using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Requisition.Services.Interfaces;
using Requisition.DataAccess.Interfaces;
using Requisition.DataAccess.Enitites;
using Requisition.DataAccess.EntityDTO;

namespace Requisition.Services.Repositories
{
    public class ReqInfoService : IReqInfoService
    {
        private readonly IGenericRepository<RequisitionRecord> _repoRequisitionRecord;
        public ReqInfoService(IGenericRepository<RequisitionRecord> repoRequisitionRecord)
        {
            _repoRequisitionRecord = repoRequisitionRecord;
        }
        public async Task<bool> AddRequisition(RequisitionRecordDTO requisitionRecordDTO)
        {
            bool Isflag = true;
            try
            {
                RequisitionRecord requisitionRecord = MappedEntity(requisitionRecordDTO);
                _repoRequisitionRecord.Add(requisitionRecord);
                await _repoRequisitionRecord.SaveAsyn();
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
                Isflag = false;
            }
            return Isflag;
        }

        public List<RequisitionRecordDTO> GetRequisition()
        {
            return _repoRequisitionRecord.GetAll().Select(x => new RequisitionRecordDTO { TestName = x.TestName, SpecimenType = x.SpecimenType, FacilityId = x.FacilityId, PatientId = x.PatientId }).ToList();
        }

        public RequisitionRecord MappedEntity(RequisitionRecordDTO requisitionRecordDTO)
        {
            RequisitionRecord requisitionRecord = new RequisitionRecord
            {
                TestName = requisitionRecordDTO.TestName,
                SpecimenType = requisitionRecordDTO.SpecimenType,
                FacilityId = requisitionRecordDTO.FacilityId,
                PatientId = requisitionRecordDTO.PatientId,
            };
            return requisitionRecord;
        }
    }
}
