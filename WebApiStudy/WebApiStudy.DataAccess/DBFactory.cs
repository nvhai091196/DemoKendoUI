using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess
{
    public class DbFactory : IDbFactory
    {
        DemoDBEntities dbContext;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DemoDBEntities Init()
        {
            return dbContext ?? (dbContext = new DemoDBEntities());
        }
    }
}
