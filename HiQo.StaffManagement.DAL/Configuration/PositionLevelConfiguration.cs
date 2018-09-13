using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class PositionLevelConfiguration : EntityTypeConfiguration<PositionLevel>
    {
        public PositionLevelConfiguration()
        {
            ToTable("PositionLevels")
                .HasKey(g => g.PositionLevelId)
                .Property(g => g.PositionLevelId)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.Level)
                .HasColumnName("Level")
                .IsOptional();

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Name");

            HasMany(g => g.Users).WithRequired(x => x.PositionLevel).WillCascadeOnDelete(false);
        }
    }
}