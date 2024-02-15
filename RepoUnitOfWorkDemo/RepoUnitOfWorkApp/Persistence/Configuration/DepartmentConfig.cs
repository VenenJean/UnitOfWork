using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepoUnitOfWorkApp.Entities;

namespace RepoUnitOfWorkApp.Persistence.Configuration;

public class DepartmentConfig : IEntityTypeConfiguration<Department> {
  public void Configure(EntityTypeBuilder<Department> builder) {
    builder.ToTable("Departments");
    builder.HasIndex(department => department.Id);

    builder.Property(department => department.Name).HasMaxLength(100);

    builder.HasMany(department => department.Employees);
  }
}