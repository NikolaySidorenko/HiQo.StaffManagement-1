namespace HiQo.StaffManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFkAndProp : DbMigration
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
            RenameColumn(table: "dbo.Users", name: "Email", newName: "E-mail");
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "MainPhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Users", "SecondPhoneNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "E-mail", c => c.String(nullable: false, maxLength: 40));
            AddForeignKey("dbo.Positions", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id");
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id");
            AddForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels", "Id");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
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
            AlterColumn("dbo.Users", "E-mail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "SecondPhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "MainPhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Users", name: "E-mail", newName: "Email");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "PositionLevelId", "dbo.PositionLevels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "PositionId", "dbo.Positions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Categories", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Positions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: false);
        }
    }
}
