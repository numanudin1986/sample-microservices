using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.DataAccess.Enitites
{
    public class PatientContext  : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
              : base(options)
        {

        }
        public virtual DbSet<PatientRecord> PatientRecords { get; set; }

    }
}
