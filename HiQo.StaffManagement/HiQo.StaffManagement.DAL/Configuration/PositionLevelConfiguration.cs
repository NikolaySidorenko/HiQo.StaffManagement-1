using System.Data.Entity.ModelConfiguration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Configuration
{
    public class PositionLevelConfiguration : EntityTypeConfiguration<PositionLevel>
    {
        public PositionLevelConfiguration()
        {
            Property(g => g.Id)
                .IsRequired();

            Property(g => g.Level)
                .IsOptional(); //TODO:Range 0-2

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}