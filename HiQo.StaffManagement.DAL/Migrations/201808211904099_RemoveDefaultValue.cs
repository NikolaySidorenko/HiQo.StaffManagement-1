namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDefaultValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DepartmentId", c => c.Int(nullable: true));
            AlterColumn("dbo.Users", "CategoryId", c => c.Int(nullable: true));
            AlterColumn("dbo.Users", "PositionId", c => c.Int(nullable: true));
            AlterColumn("dbo.Users", "PositionLevelId", c => c.Int(nullable: true));
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
