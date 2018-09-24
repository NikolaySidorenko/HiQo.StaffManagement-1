using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class TokenConfiguration : EntityTypeConfiguration<Token>
    {
        public TokenConfiguration()
        {
            ToTable("Tokens")
                .HasKey(g => g.Id)
                .Property(g => g.Id)
                .HasColumnName("Id")
                .IsRequired();


            Property(g => g.RefreshToken)
                .IsRequired()
                .HasColumnName("RefreshToken");

            HasRequired(g => g.User).WithMany(x => x.Tokens).HasForeignKey(g => g.UserId);
        }
    }
}
