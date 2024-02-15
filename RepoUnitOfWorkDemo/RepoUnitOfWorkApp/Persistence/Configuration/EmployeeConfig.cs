using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepoUnitOfWorkApp.Entities;

namespace RepoUnitOfWorkApp.Persistence.Configuration;

public class EmployeeConfig : IEntityTypeConfiguration<Employee> {
  public void Configure(EntityTypeBuilder<Employee> builder) {
    builder.ToTable("Employees");
    builder.HasIndex(employee => employee.Id);

    builder.Property(employee => employee.Name).HasMaxLength(50);
    builder.Property(employee => employee.Email).HasMaxLength(50);
    builder.Property(employee => employee.Position).HasMaxLength(80);

    builder.HasOne(employee => employee.Department);
  }
}