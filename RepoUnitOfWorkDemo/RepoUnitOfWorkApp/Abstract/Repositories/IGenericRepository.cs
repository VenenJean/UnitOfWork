using System.Linq.Expressions;

namespace RepoUnitOfWorkApp.Abstract.Repositories;

public interface IGenericRepository<T> where T : class {
  Task<IEnumerable<T>> GetAllAsync(
    Expression<Func<T, bool>>? filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    string includeProperties = ""
  );
  Task<T?> GetByIdAsync(object id);
  Task InsertAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(object id);
  Task SaveChangesAsync();
}