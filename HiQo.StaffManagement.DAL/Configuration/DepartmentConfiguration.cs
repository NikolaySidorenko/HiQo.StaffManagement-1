using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("Departments")
                .HasKey(g => g.DepartmentId)
                .Property(g => g.DepartmentId)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(30);

            HasMany(g => g.Users).WithRequired(x => x.Department).WillCascadeOnDelete(false);
            HasMany(g => g.CategoryNames).WithRequired(x => x.Department).WillCascadeOnDelete(false);
        }
    }
}