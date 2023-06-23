using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.DataAccess.EntityDTO
{
    public class PatientRecordDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Ethnicity { get; set; }
        public string? Address { get; set; }

    }
}
