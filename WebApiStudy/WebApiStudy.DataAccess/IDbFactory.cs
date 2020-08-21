using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess
{
    public interface IDbFactory : IDisposable
    {
        DemoDBEntities Init();
    }
}
