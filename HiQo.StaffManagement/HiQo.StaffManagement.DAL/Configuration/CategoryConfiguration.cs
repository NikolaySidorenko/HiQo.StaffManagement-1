using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories")
                .HasKey(g => g.CategoryId)
                .Property(g => g.CategoryId)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name");

            HasMany(g => g.Users).WithRequired(x => x.Category).WillCascadeOnDelete(false);
            HasMany(g => g.CategoryPositions).WithRequired(x => x.Category).WillCascadeOnDelete(false);

            HasRequired(g => g.Department).WithMany(x => x.CategoryNames).HasForeignKey(g => g.DepartmentId);
        }
    }
}