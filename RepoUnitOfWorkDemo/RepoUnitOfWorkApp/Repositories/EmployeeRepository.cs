using Microsoft.EntityFrameworkCore;
using RepoUnitOfWorkApp.Abstract.Repositories;
using RepoUnitOfWorkApp.Entities;
using RepoUnitOfWorkApp.Persistence;

namespace RepoUnitOfWorkApp.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository {
  public EmployeeRepository(MyDbContext context) : base(context) { }
  
  public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() {
    return await Context.Employees
      .Include(e => e.Department)
      .ToListAsync();
  }
  
  public async Task<Employee?> GetEmployeeByIdAsync(int employeeId) {
    var employee = await Context.Employees
      .Include(e => e.Department)
      .FirstOrDefaultAsync(m => m.Id == employeeId);
    return employee;
  }
  
  public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId) {
    return await Context.Employees
      .Where(emp => emp.DepartmentId == departmentId)
      .Include(e => e.Department)
      .ToListAsync();
  }

  public async Task InsertEmployeeAsync(Employee employee) {
    await DbSet.AddAsync(employee);
  }
}