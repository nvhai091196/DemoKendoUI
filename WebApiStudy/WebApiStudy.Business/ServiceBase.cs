using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStudy.DataAccess;
using WebApiStudy.DataAccess.Repositories;

namespace WebApiStudy.Business
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        bool Create(T entity);
        bool Update(T entity);

        bool Delete(T entity);

    }
    public class ServiceBase<T> : IServiceBase<T> where T : class
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


        public IEnumerable<T> Get()
        {
            return repository.GetAll();
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


     
    }
}