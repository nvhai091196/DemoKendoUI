using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private DataAccessContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DataAccessContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public bool Commit()
        {
            return DbContext.Commit() > 0;
        }
    }
}
