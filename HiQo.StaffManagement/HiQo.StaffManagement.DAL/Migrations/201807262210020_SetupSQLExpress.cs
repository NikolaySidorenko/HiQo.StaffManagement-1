namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupSQLExpress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        BirthDate = c.DateTime(nullable: true),
                        MainPhoneNumber = c.String(nullable: true, maxLength: 20),
                        Email = c.String(name: "E-mail", nullable: true, maxLength: 40),
                        DepartmentId = c.Int(nullable: true),
                        CategoryId = c.Int(nullable: true),
                        PositionId = c.Int(nullable: true),
                        PositionLevelId = c.Int(nullable: true),
                        RoleId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.PositionLevels", t => t.PositionLevelId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CategoryId)
                .Index(t => t.PositionId)
                .Index(t => t.PositionLevelId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Level = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Positions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "PositionLevelId" });
            DropIndex("dbo.Users", new[] { "PositionId" });
            DropIndex("dbo.Users", new[] { "CategoryId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Positions", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "DepartmentId" });
            DropTable("dbo.Roles");
            DropTable("dbo.PositionLevels");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.Positions");
            DropTable("dbo.Categories");
        }
    }
}
