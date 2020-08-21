using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStudy.DataAccess.Models;

namespace WebApiStudy.DataAccess.Mappers
{
     public  class StaffMapper : EntityTypeConfiguration<Staff>
    {
        public StaffMapper()
        {
            this.ToTable("Staff");
            this.HasKey(x => x.Id);
        }
    }
}
