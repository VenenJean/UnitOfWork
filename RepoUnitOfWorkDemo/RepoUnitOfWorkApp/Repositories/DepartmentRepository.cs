using RepoUnitOfWorkApp.Abstract.Repositories;
using RepoUnitOfWorkApp.Entities;
using RepoUnitOfWorkApp.Persistence;

namespace RepoUnitOfWorkApp.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository {
  public DepartmentRepository(MyDbContext context) : base(context) { }
}