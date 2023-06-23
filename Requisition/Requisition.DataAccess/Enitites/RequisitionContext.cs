using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requisition.DataAccess.Enitites
{
    public class RequisitionContext  : DbContext
    {
        public RequisitionContext(DbContextOptions<RequisitionContext> options)
              : base(options)
        {

        }
        public virtual DbSet<RequisitionRecord> RequisitionRecords { get; set; }

    }
}
