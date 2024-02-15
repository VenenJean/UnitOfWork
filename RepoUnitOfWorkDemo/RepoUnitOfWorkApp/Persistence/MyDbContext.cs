using Microsoft.EntityFrameworkCore;
using RepoUnitOfWorkApp.Entities;

namespace RepoUnitOfWorkApp.Persistence;

public class MyDbContext : DbContext {
  public DbSet<Employee> Employees { get; set; }
  public DbSet<Department> Departments { get; set; }

  public MyDbContext() { }
  public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
  
  private const string ConnectionString =
    $"server=localhost;" +
    $"port=3306;" +
    $"user=root;" +
    $"password=Antidote2580134679#;" +
    $"database=Repositories;";

  // OnConfiguring() method is used to select and configure the data source
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //We will store the connection string in AppSettings.json file instead of hard coding here
    optionsBuilder.UseMySql(ConnectionString,
      new MariaDbServerVersion(new Version(11, 2, 2)));
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
  }
}