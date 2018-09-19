namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecurityStamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SecurityStamp");
        }
    }
}
