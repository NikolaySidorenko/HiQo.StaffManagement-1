namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_ExceptionLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionLogs",
                c => new
                    {
                        ExceptionLogId = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Url = c.String(),
                        ExceptionClass = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ExceptionLogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExceptionLogs");
        }
    }
}
