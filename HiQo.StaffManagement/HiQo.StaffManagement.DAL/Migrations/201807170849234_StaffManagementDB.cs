using System.Data.Entity.Migrations;

namespace HiQo.StaffManagement.DAL.Migrations
{
    public partial class StaffManagementDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Categories",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 40),
                        DepartmentId = c.Int(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, true)
                .Index(t => t.DepartmentId);

            CreateTable(
                    "dbo.Departments",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 40)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Positions",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 40),
                        PositionLevelId = c.Int(false),
                        Category_Id = c.Int()
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PositionLevels", t => t.PositionLevelId, true)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.PositionLevelId)
                .Index(t => t.Category_Id);

            CreateTable(
                    "dbo.PositionLevels",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 40),
                        Level = c.Int()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Roles",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false, 40)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        FirstName = c.String(false, 30),
                        LastName = c.String(false, 30),
                        BirthDate = c.DateTime(false),
                        MainPhoneNumber = c.String(false),
                        SecondPhoneNumber = c.String(),
                        Email = c.String(false),
                        CategoryId = c.Int(false),
                        PositionId = c.Int(false),
                        RoleId = c.Int(false)
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, true)
                .ForeignKey("dbo.Positions", t => t.PositionId, true)
                .ForeignKey("dbo.Roles", t => t.RoleId, true)
                .Index(t => t.CategoryId)
                .Index(t => t.PositionId)
                .Index(t => t.RoleId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Positions", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Positions", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] {"RoleId"});
            DropIndex("dbo.Users", new[] {"PositionId"});
            DropIndex("dbo.Users", new[] {"CategoryId"});
            DropIndex("dbo.Positions", new[] {"Category_Id"});
            DropIndex("dbo.Positions", new[] {"PositionLevelId"});
            DropIndex("dbo.Categories", new[] {"DepartmentId"});
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.PositionLevels");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}