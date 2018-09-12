using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            ToTable("Positions")
                .HasKey(g => g.PositionId)
                .Property(g => g.PositionId)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name");

            HasMany(g => g.Users).WithRequired(x => x.Position).WillCascadeOnDelete(false);
        }
    }
}