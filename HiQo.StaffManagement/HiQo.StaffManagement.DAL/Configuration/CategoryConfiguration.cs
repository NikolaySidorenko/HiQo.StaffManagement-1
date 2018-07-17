using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(g => g.Id)
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);

            Property(g => g.DepartmentId)
                .IsRequired();
        }
    }
}