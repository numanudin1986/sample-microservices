using Facility.DataAccess.Entities;
using Facility.DataAccess.EntityDTO;
using Facility.DataAccess.Interfaces;
using Facility.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facility.Services.Repositories
{
    public class FacilityInfoService : IFacilityInfoService
    {
        private readonly IGenericRepository<FacilityInfo> _facilityInfo;
        public FacilityInfoService(IGenericRepository<FacilityInfo> facilityInfo)
        {
            _facilityInfo = facilityInfo;
        }
        public async Task<bool> AddFacility(FacilityInfoDTO facilityInfoDTO)
        {
            bool Isflag = true;
            try
            {
                FacilityInfo requisitionRecord = MappedEntity(facilityInfoDTO);
                _facilityInfo.Add(requisitionRecord);
                await _facilityInfo.SaveAsyn();
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
                Isflag = false;
            }
            return Isflag;
        }

        public FacilityInfo MappedEntity(FacilityInfoDTO facilityInfDTO)
        {
            FacilityInfo facilityInfo = new FacilityInfo
            {
                FacilityName = facilityInfDTO.FacilityName,
                ContactNumber = facilityInfDTO.ContactNumber,
                Address = facilityInfDTO.Address,
                Email = facilityInfDTO.Email,
            };
            return facilityInfo;
        }
        public List<FacilityInfoDTO> GetFacility()
        {
            return _facilityInfo.GetAll().Select(x => new FacilityInfoDTO {Email =x.Email,Address =x.Address,FacilityName = x.FacilityName,ContactNumber = x.ContactNumber  }).ToList();
        }
    }
}
