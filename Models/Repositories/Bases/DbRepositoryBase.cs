using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CQRSDEMO.Models.Repositories.Bases
{
    public class DbRepositoryBase<T> : IDisposable, IDbRepositoryBase<T> where T : class
    {
        protected DbContext DbContext;
        protected DbSet<T> DbSet;

        protected DbRepositoryBase(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync();
            DbContext.Entry<T>(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<T> AddStateDetachedAsync(T entity)
        {
            DbSet.Add(entity);
            await DbContext.SaveChangesAsync();
            DbContext.Entry<T>(entity).State = EntityState.Detached;
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public bool Any(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = DbSet;
            return query.Any(where);
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = DbSet;
            return where == null ? query.Count() : query.Count(where);
        }

        public void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            DbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.AsNoTracking().FirstOrDefault(where);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(where);
        }

        public T Get(Expression<Func<T, bool>>[] wheres, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }

            foreach (var where in wheres)
            {
                query = query.Where(where);
            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>[] wheres, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }

            foreach (var where in wheres)
            {
                query = query.Where(where);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.AsNoTracking().Where(where);
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;

            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }



            return await query.AsNoTracking().Where(where).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetManyWithDeepIncludeAsync(
    Expression<Func<T, bool>> where,
    Func<IQueryable<T>, IQueryable<T>> includes, int skip = 0, int take = 10)
        {
            IQueryable<T> query = includes(DbSet);
            return await query.AsNoTracking().Where(where).Skip(skip).Take(take).ToListAsync();
        }

        public IEnumerable<T> GetManyWithPaging(Expression<Func<T, bool>> where, int skip, int take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.AsNoTracking().Where(where).Skip(skip).Take(take);
        }

        public IEnumerable<T> GetManyWithPagingDESC(Expression<Func<T, bool>> where, int skip, int take, Expression<Func<T, object>> orderSelector, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }

            return query.AsNoTracking().Where(where).OrderByDescending(orderSelector).Skip(skip).Take(take);
        }


        public IEnumerable<T> GetManyWithPagingASC(Expression<Func<T, bool>> where, int skip, int take, Expression<Func<T, object>> orderSelector, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }

            return query.AsNoTracking().Where(where).OrderBy(orderSelector).Skip(skip).Take(take);
        }

        public TResult Query<TResult>(Func<IQueryable<T>, TResult> queryFunction)
        {
            IQueryable<T> query = DbSet;
            return queryFunction(query);
        }

        public T Update(T entity)
        {
            DbSet.Update(entity);
            DbContext.SaveChanges();
            return entity;
        }
        public async Task<T> UpdateAsynchronous(T entity)
        {

            var data = DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {

            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
            DbContext.Entry<T>(entity).State = EntityState.Detached;

            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            DbContext.UpdateRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
