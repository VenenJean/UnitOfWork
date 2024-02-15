using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepoUnitOfWorkApp.Abstract.Repositories;
using RepoUnitOfWorkApp.Persistence;

namespace RepoUnitOfWorkApp.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class {
  protected readonly MyDbContext Context;
  protected readonly DbSet<T> DbSet;
  
  protected GenericRepository(MyDbContext context) {
    Context = context;
    DbSet = context.Set<T>();
  }

  public async Task<IEnumerable<T>> GetAllAsync(
    Expression<Func<T, bool>>? filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    string includeProperties = ""
  ) {
    IQueryable<T> query = DbSet;

    if (filter is not null) {
      query = query.Where(filter);
    }

    var splitProperties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (var property in splitProperties) {
      query = query.Include(property);
    }

    return orderBy is not null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
  }

  public async Task<T?> GetByIdAsync(object id) {
    return await DbSet.FindAsync(id);
  }

  public async Task InsertAsync(T entity) {
    await DbSet.AddAsync(entity);
  }

  public Task UpdateAsync(T entity) {
    DbSet.Update(entity);
    return Task.CompletedTask;
  }

  public async Task DeleteAsync(object id) {
    var entity = await DbSet.FindAsync(id);
    if (entity is null) return;
    DbSet.Remove(entity);
  }

  public async Task SaveChangesAsync() {
    await Context.SaveChangesAsync();
  }
}