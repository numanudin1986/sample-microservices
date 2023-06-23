using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient.DataAccess.EntityDTO;
namespace Patient.Services.Interfaces
{
    public interface IPatientInfoService
    {
       Task<bool> AddPatient(PatientRecordDTO patientRecordDTO);
       List<PatientRecordDTO> GetPatient();
    }
}
