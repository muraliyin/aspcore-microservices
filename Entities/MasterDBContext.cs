using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace aspcorewebapis.Entities
{
    public partial class MasterDBContext : DbContext
    {
        public MasterDBContext() { }
        public MasterDBContext(DbContextOptions<MasterDBContext> options) : base(options) { }

        public virtual DbSet<Companies> Companies { get; set; }
    }
}
