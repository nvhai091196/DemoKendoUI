using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess
{
    public class DbFactory : IDbFactory
    {
        DataAccessContext dbContext;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataAccessContext Init()
        {
            return dbContext ?? (dbContext = new DataAccessContext());
        }
    }
}
