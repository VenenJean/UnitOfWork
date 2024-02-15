using RepoUnitOfWorkApp.Primitives;

namespace RepoUnitOfWorkApp.Entities;

public class Employee : Entity {
  public string Name { get; set; }
  public string Email { get; set; }
  public string Position { get; set; }
  //[Display(Name ="Department Name")]
  
  public int DepartmentId { get; init; }
  public Department Department { get; init; } = null!;
  
  public Employee(int id, string name, string email, string position) : base(id) {
    Name = name;
    Email = email;
    Position = position;
  }
}