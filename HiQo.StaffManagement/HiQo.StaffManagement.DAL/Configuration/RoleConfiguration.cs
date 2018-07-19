using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles")
                .HasKey(g => g.RoleId)
                .Property(g => g.RoleId)
                .HasColumnName("Id")
                .IsRequired();

            HasMany(g => g.Users).WithRequired(x => x.Role).WillCascadeOnDelete(false);

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name");
        }
    }
}