using Motd.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Repositories.Contracts
{
    public class MotdRepository<T> : IMotdRepository<T> where T : class
    {
        protected readonly MotdContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public MotdRepository(MotdContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual int Count
        {
            get { return _dbSet.Count(); }
        }

        public virtual IQueryable<T> All()
        {
            return _dbSet.AsQueryable();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            Debug.Assert(_dbSet != null, "_dbSet != null");
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!String.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (query != null)
                        query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }
            else
            {
                return query.AsQueryable();
            }
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 9)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual T Create(T entity)
        {
            var newEntry = _dbSet.Add(entity);
            return newEntry;
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }
        }

        public virtual void Update(T entity)
        {
            /*
             Attach is used to repopulate a context with an entity that is known to already exist in the database. 
             SaveChanges will therefore not attempt to insert an attached entity into the database because it is assumed to already be there. 
             Note that entities that are already in the context in some other state will have their state set to Unchanged. 
             Attach is a no-op if the entity is already in the context in the Unchanged state.
            */
            var entry = _dbContext.Entry(entity);
            _dbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            var result = ((IObjectContextAdapter)_dbContext).ObjectContext.ExecuteFunction(functionName, parameters);
            return result;
        }

        public int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            return ((IObjectContextAdapter)_dbContext).ObjectContext.ExecuteStoreCommand(commandText, parameters);
        }

        public IQueryable<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            var result = ((IObjectContextAdapter)_dbContext).ObjectContext.ExecuteStoreQuery<TElement>(commandText, parameters);
            return result.AsQueryable<TElement>();
        }

        public IQueryable SqlQuery(Type elementType, string sql, params object[] parameters)
        {
            var result = _dbContext.Database.SqlQuery(elementType, sql, parameters);
            return result.AsQueryable();
        }

        public IQueryable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            var result = _dbContext.Database.SqlQuery<TElement>(sql, parameters);
            return result.AsQueryable<TElement>();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}

