using WebApiStudy.DataAccess.Repositories;

namespace WebApiStudy.DataAccess.Repositories
{
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IStaffRepository :  IRepository<Staff>
    {
    }

}