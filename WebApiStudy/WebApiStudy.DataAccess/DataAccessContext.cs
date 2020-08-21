using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApiStudy.DataAccess.Mappers;

namespace WebApiStudy.DataAccess
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("name=ConnectionString") {
        }

        public virtual int Commit()
        {
            return base.SaveChanges(); 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataAccessContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new StaffMapper());
        }
    }
}
