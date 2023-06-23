using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facility.DataAccess.EntityDTO;
namespace Facility.Services.Interface
{
    public interface IFacilityInfoService
    {
        Task<bool> AddFacility(FacilityInfoDTO facilityInfoDTO);
        List<FacilityInfoDTO> GetFacility();
    }

}
