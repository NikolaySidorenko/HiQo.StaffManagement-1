using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HiQo.StaffManagement.DAL.Configuration;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Context
{
    public class StaffManagementContext : DbContext
    {
        public StaffManagementContext() : base("StaffManagementContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StaffManagementContext, Migrations.Configuration>());
        }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Department> Departments { get; set; }

        public virtual IDbSet<Position> Positions { get; set; }

        public virtual IDbSet<PositionLevel> PositionLevels { get; set; }

        public virtual IDbSet<Role> Roles { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//??;
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new PositionLevelConfiguration());
        }
    }
}