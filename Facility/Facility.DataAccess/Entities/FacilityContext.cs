using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facility.DataAccess.Entities
{
    public class FacilityContext : DbContext
    {
        public FacilityContext(DbContextOptions<FacilityContext> options)
             : base(options)
        {
            
        }
        public virtual DbSet<FacilityInfo> FacilityInfos { get; set; }
    }
}
