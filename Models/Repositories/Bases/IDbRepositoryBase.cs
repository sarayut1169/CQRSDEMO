using System.Linq.Expressions;

namespace CQRSDEMO.Models.Repositories.Bases
{
    public interface IDbRepositoryBase<T> where T : class
    {
        // Basic
        T Add(T entity);
        Task<T> AddAsync(T entity);
        Task<T> AddStateDetachedAsync(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        //These SELECT queries are capable of 1 level of ordering and 1 level relationship but n table(s).
        //if you need more deeper level, please use TResult Query below
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>>[] wheres, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>>[] wheres, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetManyWithPaging(Expression<Func<T, bool>> where, int skip, int take, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetManyWithPagingASC(Expression<Func<T, bool>> where, int skip, int take, Expression<Func<T, object>> orderSelector, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetManyWithPagingDESC(Expression<Func<T, bool>> where, int skip, int take, Expression<Func<T, object>> orderSelector, params Expression<Func<T, object>>[] includes);

        //Specific
        bool Any(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where = null);

        //Complex - Capable of any queries (like query string) but in Lamda form to avoid human string error
        TResult Query<TResult>(Func<IQueryable<T>, TResult> queryFunction);


        Task<IEnumerable<T>> GetManyWithDeepIncludeAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IQueryable<T>> includes, int skip = 0, int take = 10);
    }
}
