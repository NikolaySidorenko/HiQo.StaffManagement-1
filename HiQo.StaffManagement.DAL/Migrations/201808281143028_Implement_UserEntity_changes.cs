namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implement_UserEntity_changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Latitude", c => c.String());
            AddColumn("dbo.Users", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Longitude");
            DropColumn("dbo.Users", "Latitude");
        }
    }
}
