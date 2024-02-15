using RepoUnitOfWorkApp.Primitives;

namespace RepoUnitOfWorkApp.Entities;

public class Department : Entity {
  public string Name { get; set; }
  public List<Employee> Employees { get; init; } = new();
  
  public Department(int id, string name) : base(id) {
    Name = name;
  }
}