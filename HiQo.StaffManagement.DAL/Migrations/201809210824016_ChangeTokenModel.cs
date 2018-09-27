namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTokenModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "RefreshToken", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "RefreshToken", c => c.String());
        }
    }
}
