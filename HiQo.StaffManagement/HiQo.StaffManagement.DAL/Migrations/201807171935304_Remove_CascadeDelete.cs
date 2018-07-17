namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Positions", new[] { "PositionLevelId" });
            DropIndex("dbo.Positions", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Positions", name: "Category_Id", newName: "CategoryId");
            AddColumn("dbo.Users", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "PositionLevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Positions", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.PositionLevels", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            CreateIndex("dbo.Positions", "CategoryId");
            CreateIndex("dbo.Users", "DepartmentId");
            CreateIndex("dbo.Users", "PositionLevelId");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels", "Id");
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            DropColumn("dbo.Positions", "PositionLevelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Positions", "PositionLevelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "PositionLevelId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Positions", new[] { "CategoryId" });
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.PositionLevels", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Positions", "CategoryId", c => c.Int());
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 40));
            DropColumn("dbo.Users", "PositionLevelId");
            DropColumn("dbo.Users", "DepartmentId");
            RenameColumn(table: "dbo.Positions", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Positions", "Category_Id");
            CreateIndex("dbo.Positions", "PositionLevelId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Positions", "PositionLevelId", "dbo.PositionLevels", "Id", cascadeDelete: false);
        }
    }
}
