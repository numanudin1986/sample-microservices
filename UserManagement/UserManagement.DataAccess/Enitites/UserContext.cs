using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.DataAccess.Enitites
{
    public class UserContext  : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
              : base(options)
        {

        }
        public virtual DbSet<UserRecord> UserRecords { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

    }
}
