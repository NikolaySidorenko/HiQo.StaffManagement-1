using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users")
                .HasKey(g => g.Id)
                .Property(g => g.Id)
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
                .HasColumnName("MainPhoneNumber")
                .HasMaxLength(20);

            Property(g => g.Email)
                .HasColumnName("E-mail")
                .HasMaxLength(40);

            Property(g => g.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("datetime2");
        }
    }
}