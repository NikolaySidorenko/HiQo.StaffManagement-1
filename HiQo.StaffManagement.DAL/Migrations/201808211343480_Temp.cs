namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Users", "MainPhoneNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "E-mail", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "E-mail", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Users", "MainPhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
