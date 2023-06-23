using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient.Services.Interfaces;
using Patient.DataAccess.Interfaces;
using Patient.DataAccess.Enitites;
using Patient.DataAccess.EntityDTO;

namespace Patient.Services.Repositories
{
    public class PatientInfoService : IPatientInfoService
    {
        private readonly IGenericRepository<PatientRecord> _repoPatientRecord;
        public PatientInfoService(IGenericRepository<PatientRecord> repoPatientRecord)
        {
            _repoPatientRecord = repoPatientRecord;
        }
        public async Task<bool> AddPatient(PatientRecordDTO patientRecordDTO)
        {
            bool IsFlag = true;
            try
            {
                PatientRecord patientRecord = MappedEntity(patientRecordDTO);
                _repoPatientRecord.Add(patientRecord);
                await _repoPatientRecord.SaveAsyn();
                return IsFlag;
            }
            catch (Exception ex)
            {
                string Msg = ex.Message;
                return IsFlag = false;
            }
        }

        public List<PatientRecordDTO> GetPatient()
        {
            return _repoPatientRecord.GetAll().Select(x => new PatientRecordDTO { FirstName = x.FirstName, LastName = x.LastName, Address = x.Address, Email = x.Email, DOB = x.DOB, Ethnicity = x.Ethnicity, Gender = x.Gender }).ToList();
        }

        public PatientRecord MappedEntity(PatientRecordDTO patientRecordDTO)
        {
            PatientRecord patientRecord = new PatientRecord
            {
                FirstName = patientRecordDTO.FirstName,
                LastName = patientRecordDTO.LastName,
                Address = patientRecordDTO.Address,
                DOB = patientRecordDTO.DOB,
                Email = patientRecordDTO.Email,
                Ethnicity = patientRecordDTO.Ethnicity
            };
            return patientRecord;
        }
    }
}
