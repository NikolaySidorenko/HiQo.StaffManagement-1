using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(g => g.Id)
                .IsRequired();

            Property(g => g.FirstName)
                .IsRequired();

            Property(g => g.LastName)
                .IsRequired()
                .HasMaxLength(30);

            Property(g => g.MainPhoneNumber)
                .IsRequired();

            Property(g => g.SecondPhoneNumber)
                .IsOptional();

            Property(g => g.Email)
                .IsRequired();

            Property(g => g.BirthDate)
                .IsRequired();

            Property(g => g.PositionId)
                .IsRequired();

            Property(g => g.RoleId)
                .IsRequired();

            Property(g => g.CategoryId)
                .IsRequired();

            Property(g => g.DepartmentId)
                .IsRequired();

            Property(g => g.PositionLevelId)
                .IsRequired();
        }
    }
}