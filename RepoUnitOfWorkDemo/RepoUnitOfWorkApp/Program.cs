using Microsoft.EntityFrameworkCore;
using RepoUnitOfWorkApp.Entities;
using RepoUnitOfWorkApp.Persistence;
using RepoUnitOfWorkApp.Repositories;

namespace RepoUnitOfWorkApp;

class Program {
  static async Task Main(string[] args) {
    // var services = new ServiceCollection();
    // services.AddDbContext<MyDbContext>(options => {
    //   options.UseMySql(connectionString, new MariaDbServerVersion(new Version(11, 2, 2)));
    // });
    //
    // // Add ControllersWithViews
    //
    // services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

    await Runner.Start();
  }
}

class Runner {
  public static async Task Start() {
    var dbContext = new MyDbContext();
    await dbContext.Database.MigrateAsync();
    
    var unitOfWork = new UnitOfWork.UnitOfWork(dbContext);
    
    var employeeRepository = new EmployeeRepository(dbContext);
    var depart = new Department(4, "Software Development");
    depart.Employees.Add(new Employee(9, "Venen", "venenjean@gmail.com", "Manager"));
    await dbContext.Departments.AddAsync(depart);
    await dbContext.SaveChangesAsync();

    var employees = await employeeRepository.GetAllEmployeesAsync();
    
    var departmentRepository = new DepartmentRepository(dbContext);
    var departments = await departmentRepository.GetAllAsync();

    foreach (var employee in employees) {
      Console.WriteLine(employee.Id);
      Console.WriteLine(employee.Name);
      Console.WriteLine(employee.Email);
      Console.WriteLine(employee.Position);
      Console.WriteLine(employee.DepartmentId);
    }

    Console.WriteLine("=============================================================================================");
    
    foreach (var employee in departments) {
      Console.WriteLine(employee.Id);
      Console.WriteLine(employee.Name);
    }
  }
}