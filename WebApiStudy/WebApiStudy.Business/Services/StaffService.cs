using WebApiStudy.DataAccess;
using WebApiStudy.DataAccess.Models;
using WebApiStudy.DataAccess.Repositories;

namespace WebApiStudy.Business.Services
{
    public interface IStaffService : IServiceBase<Staff>
    {
    }

    public class StaffService : ServiceBase<Staff>, IStaffService
    {
        public StaffService(IRepository<Staff> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
