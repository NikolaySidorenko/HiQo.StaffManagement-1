namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelsForMaps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "Latitude", c => c.Double());
            AlterColumn("dbo.Users", "Longitude", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Longitude", c => c.String());
            AlterColumn("dbo.Users", "Latitude", c => c.String());
            DropColumn("dbo.Users", "Address");
        }
    }
}
