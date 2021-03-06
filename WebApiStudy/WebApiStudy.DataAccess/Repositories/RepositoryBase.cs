﻿ 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiStudy.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private DemoDBEntities dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DemoDBEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation

        public virtual IDbSet<T> DBSet()
        {
            return dbSet;
        }
        public virtual void Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
            }catch(Exception ex)
            {
                System.Console.WriteLine(ex);
            }
            
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }
 

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
        public virtual void CreateRange(List<T> entities)
        {
            foreach (var i in entities)
            {
                dbSet.Add(i);
            }
        }
        #endregion

    }
}
