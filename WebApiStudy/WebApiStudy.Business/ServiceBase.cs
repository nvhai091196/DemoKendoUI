using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStudy.DataAccess;
using WebApiStudy.DataAccess.Models;
using WebApiStudy.DataAccess.Repositories;

namespace WebApiStudy.Business
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Create(T entity);
        //bool CreateRange(IList<T> entities);
        bool Update(T entity);

        bool Delete(T entity);
        //bool DeleteRs(T entity);

        bool CreateRange(List<T> entities);

        bool DeleteRange(List<int> ids);

    }
    public class ServiceBase<T> : IServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;
        protected readonly IDbSet<T> dbSet;

        public ServiceBase(IRepository<T> _repository, IUnitOfWork _unitOfWork)
        {
            this.repository = _repository;
            this.unitOfWork = _unitOfWork;
            dbSet = repository.DBSet();
        }

        public bool Create(T entity)
        {
            repository.Add(entity);
            return Save();
        }

        public bool Save()
        {
            return unitOfWork.Commit();
        }

        public bool Delete(T entity)
        {
            repository.Delete(entity);
            return Save();
        }

        //public bool DeleteRs(T entity)
        //{
        //    repository.DeleteRs(entity);
        //    return Save();
        //}

        public IEnumerable<T> Get()
        {
            return repository.GetMany(m => m.IsDeleted != true);
        }

        public T Get(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(T entity)
        {
            repository.Update(entity);
            return Save();
        }

        public bool CreateRange(List<T> entities)
        {
            repository.CreateRange(entities);
            return Save();
        }

        public bool DeleteRange(List<int> ids)
        {
            foreach (var id in ids)
            {
                var post = repository.GetById(id);
                if (post != null)
                {
                    post.IsDeleted = true;
                    repository.Update(post);
                }

            }

            return Save();
        }
    }
}