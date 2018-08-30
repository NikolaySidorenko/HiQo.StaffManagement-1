namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelsForMaps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Latitude", c => c.Double());
            AddColumn("dbo.Users", "Longitude", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Longitude");
            DropColumn("dbo.Users", "Latitude");
            DropColumn("dbo.Users", "Address");
        }
    }
}
