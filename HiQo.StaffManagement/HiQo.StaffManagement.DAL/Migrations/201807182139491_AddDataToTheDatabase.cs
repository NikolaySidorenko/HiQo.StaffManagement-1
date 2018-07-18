namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTheDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            AddForeignKey("dbo.Positions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Positions", "CategoryId", "dbo.Categories");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
            AddForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels", "Id");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id");
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Positions", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
