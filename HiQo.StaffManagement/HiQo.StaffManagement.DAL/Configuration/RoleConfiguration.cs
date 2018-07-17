using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class RoleConfiguration:EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(g => g.Id)
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
