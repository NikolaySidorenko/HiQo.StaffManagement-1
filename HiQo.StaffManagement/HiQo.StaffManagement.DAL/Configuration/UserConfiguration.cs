using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users")
                .HasKey(g => g.UserId)
                .Property(g => g.UserId)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasMaxLength(30);

            Property(g => g.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasMaxLength(30);

            Property(g => g.MainPhoneNumber)
                .IsRequired()
                .HasColumnName("MainPhoneNumber")
                .HasMaxLength(20);

            Property(g => g.SecondPhoneNumber)
                .IsOptional()
                .HasColumnName("SecondPhoneNumber")
                .HasMaxLength(20);

            Property(g => g.Email)
                .IsRequired()
                .HasColumnName("E-mail")
                .HasMaxLength(40);

            Property(g => g.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            HasRequired(g => g.Position).WithMany(x => x.Users).HasForeignKey(g => g.PositionId)
                .WillCascadeOnDelete(false);

            HasRequired(g => g.Role).WithMany(x => x.Users).HasForeignKey(g => g.RoleId).WillCascadeOnDelete(false);

            HasRequired(g => g.Category).WithMany(x => x.Users).HasForeignKey(g => g.CategoryId)
                .WillCascadeOnDelete(false);

            HasRequired(g => g.Department).WithMany(x => x.Users).HasForeignKey(g => g.DepartmentId)
                .WillCascadeOnDelete(false);

            HasRequired(g => g.PositionLevel).WithMany(x => x.Users).HasForeignKey(g => g.PositionLevelId)
                .WillCascadeOnDelete(false);
        }
    }
}