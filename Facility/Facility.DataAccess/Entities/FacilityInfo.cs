using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facility.DataAccess.Entities
{
    public class FacilityInfo
    {
        public int Id { get; set; }
        public string? FacilityName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

    }
}
