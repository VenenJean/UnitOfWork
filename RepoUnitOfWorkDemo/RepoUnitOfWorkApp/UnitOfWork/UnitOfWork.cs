using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RepoUnitOfWorkApp.Persistence;
using RepoUnitOfWorkApp.Repositories;
using RepoUnitOfWorkApp.UnitOfWork.Interfaces;

namespace RepoUnitOfWorkApp.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable {
  public readonly MyDbContext Context;
  private IDbContextTransaction? _objTran;
  public EmployeeRepository Employees { get; }
  public DepartmentRepository Departments { get; }

  public UnitOfWork(MyDbContext context) {
    Context = context;
    Employees = new EmployeeRepository(context);
    Departments = new DepartmentRepository(context);
  }
  
  public async Task CreateTransactionAsync() {
    _objTran = await Context.Database.BeginTransactionAsync();
  }

  public async Task CommitTransactionAsync() {
    await _objTran?.CommitAsync();
  }

  public async Task RollbackTransactionAsync() {
    await _objTran?.RollbackAsync();
  }

  public async Task SaveChangesAsync() {
    try {
      await Context.SaveChangesAsync();
    }
    catch (DbUpdateException ex) {
      throw new Exception(ex.Message, ex);
    }
  }

  public void Dispose() {
    Context.DisposeAsync();
  }
}