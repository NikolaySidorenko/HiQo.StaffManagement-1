namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelsForAuth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
