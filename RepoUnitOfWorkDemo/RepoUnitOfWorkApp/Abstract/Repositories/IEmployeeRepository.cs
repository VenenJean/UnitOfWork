using RepoUnitOfWorkApp.Entities;

namespace RepoUnitOfWorkApp.Abstract.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee> {
  Task<IEnumerable<Employee>> GetAllEmployeesAsync();
  Task<Employee?> GetEmployeeByIdAsync(int employeeId);
  Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);

  Task InsertEmployeeAsync(Employee employee);
}