using RepoUnitOfWorkApp.Repositories;

namespace RepoUnitOfWorkApp.UnitOfWork.Interfaces;

public interface IUnitOfWork {
  EmployeeRepository Employees { get; }
  DepartmentRepository Departments { get; }

  Task CreateTransactionAsync();
  Task CommitTransactionAsync();
  Task RollbackTransactionAsync();
  Task SaveChangesAsync();
}