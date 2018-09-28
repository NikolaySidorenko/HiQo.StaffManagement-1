namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LogId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ControllerInfoLogs", "LogId", c => c.Guid(nullable: false));
            AddColumn("dbo.ExceptionLogs", "LogId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExceptionLogs", "LogId");
            DropColumn("dbo.ControllerInfoLogs", "LogId");
        }
    }
}
