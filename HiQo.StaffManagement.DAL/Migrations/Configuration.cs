using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Entities;

namespace HiQo.StaffManagement.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StaffManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StaffManagementContext context)
        {
            var roles = new List<Role>();
            var departments = new List<Department>();
            var categories = new List<Category>();
            var positions = new List<Position>();
            var positionLevels = new List<PositionLevel>();
            var users = new List<User>();

            roles.Add(new Role { Name = "User", RoleId = 1 });
            roles.Add(new Role { Name = "Admin", RoleId = 2 });
            roles.Add(new Role { Name = "SuperAdmin", RoleId = 3 });

            departments.Add(new Department { Name = "Resource Management", DepartmentId = 1 });
            departments.Add(new Department { Name = "Software Development", DepartmentId = 2 });
            departments.Add(new Department { Name = "Quality Assurance", DepartmentId = 3 });
            departments.Add(new Department { Name = "Business Analysis", DepartmentId = 4 });

            categories.Add(new Category
            {
                Name = "Administration staff",
                DepartmentId = departments.First(g => g.Name == "Resource Management").DepartmentId,
                CategoryId = 1
            });
            categories.Add(new Category
            {
                Name = "Management",
                DepartmentId = departments.First(g => g.Name == "Resource Management").DepartmentId,
                CategoryId = 2
            });
            categories.Add(new Category
            {
                Name = ".NET Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                CategoryId = 3
            });
            categories.Add(new Category
            {
                Name = "Java Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                CategoryId = 4
            });
            categories.Add(new Category
            {
                Name = "Python Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                CategoryId = 5
            });
            categories.Add(new Category
            {
                Name = "Front-End Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                CategoryId = 6
            });
            categories.Add(new Category
            {
                Name = "Quality Assurance",
                DepartmentId = departments.First(g => g.Name == "Quality Assurance").DepartmentId,
                CategoryId = 7
            });
            categories.Add(new Category
            {
                Name = "Business Analysis",
                DepartmentId = departments.First(g => g.Name == "Business Analysis").DepartmentId,
                CategoryId = 8
            });

            positions.Add(new Position
            {
                Name = "English Teacher",
                CategoryId = categories.First(g => g.Name == "Administration staff").CategoryId,
                PositionId = 1
            });
            positions.Add(new Position
            {
                Name = "Human Resource Manager",
                CategoryId = categories.First(g => g.Name == "Administration staff").CategoryId,
                PositionId = 2
            });
            positions.Add(new Position
            {
                Name = "Accountant",
                CategoryId = categories.First(g => g.Name == "Administration staff").CategoryId,
                PositionId = 3
            });
            positions.Add(new Position
            {
                Name = "Chief Executive Officer",
                CategoryId = categories.First(g => g.Name == "Management").CategoryId,
                PositionId = 4
            });
            positions.Add(new Position
            {
                Name = "Director of Delivery",
                CategoryId = categories.First(g => g.Name == "Management").CategoryId,
                PositionId = 5
            });
            positions.Add(new Position
            {
                Name = ".NET Developer",
                CategoryId = categories.First(g => g.Name == ".NET Development").CategoryId,
                PositionId = 6
            });
            positions.Add(new Position
            {
                Name = "Java Developer",
                CategoryId = categories.First(g => g.Name == "Java Development").CategoryId,
                PositionId = 7
            });
            positions.Add(new Position
            {
                Name = "Python Developer",
                CategoryId = categories.First(g => g.Name == "Python Development").CategoryId,
                PositionId = 8
            });
            positions.Add(new Position
            {
                Name = "Front-End Developer",
                CategoryId = categories.First(g => g.Name == "Front-End Development").CategoryId,
                PositionId = 9
            });
            positions.Add(new Position
            {
                Name = "QA Engineer",
                CategoryId = categories.First(g => g.Name == "Quality Assurance").CategoryId,
                PositionId = 10
            });
            positions.Add(new Position
            {
                Name = "Business analyst",
                CategoryId = categories.First(g => g.Name == "Business Analysis").CategoryId,
                PositionId = 11
            });

            positionLevels.Add(new PositionLevel { Name = "Intern", Level = null, PositionLevelId = 1 });
            positionLevels.Add(new PositionLevel { Name = "Junior", Level = 0, PositionLevelId = 2 });
            positionLevels.Add(new PositionLevel { Name = "Junior", Level = 1, PositionLevelId = 3 });
            positionLevels.Add(new PositionLevel { Name = "Junior", Level = 2, PositionLevelId = 4 });
            positionLevels.Add(new PositionLevel { Name = "Staff", Level = 0, PositionLevelId = 5 });
            positionLevels.Add(new PositionLevel { Name = "Staff", Level = 1, PositionLevelId = 6 });
            positionLevels.Add(new PositionLevel { Name = "Staff", Level = 2, PositionLevelId = 7 });
            positionLevels.Add(new PositionLevel { Name = "Senior", Level = 0, PositionLevelId = 8 });
            positionLevels.Add(new PositionLevel { Name = "Senior", Level = 1, PositionLevelId = 9 });
            positionLevels.Add(new PositionLevel { Name = "Senior", Level = 2, PositionLevelId = 10 });

            users.Add(new User
            {
                FirstName = "Kirill",
                LastName = "Dudkov",
                BirthDate = new DateTime(1997, 10, 21),
                MainPhoneNumber = "+375(44)535-34-30",
                Email = "kirilldudkov@gmail.com",
                RoleId = roles.First(g => g.Name == "User").RoleId,
                PositionLevelId = positionLevels.First(g => g.Name == "Intern").PositionLevelId,
                PositionId = positions.First(g => g.Name == ".NET Developer").PositionId,
                CategoryId = categories.First(g => g.Name == ".NET Development").CategoryId,
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                UserName = "kirilldudkov@gmail.com",
                PasswordHash = "AKd7l6Ssw0C1mWOWviDxzXYFpWt7/6pNyN0sgEgk3VpNwc3qeWUH83tzktoDIQ2KAg=="
            });
            users.Add(new User
            {
                FirstName = "Nikolay",
                LastName = "Sidorenko",
                BirthDate = new DateTime(1999, 5, 20),
                MainPhoneNumber = "+375(29)111-22-23",
                Email = "nsidorenko@gmail.com",
                RoleId = roles.First(g => g.Name == "User").RoleId,
                PositionLevelId = positionLevels.First(g => g.Name == "Intern").PositionLevelId,
                PositionId = positions.First(g => g.Name == ".NET Developer").PositionId,
                CategoryId = categories.First(g => g.Name == ".NET Development").CategoryId,
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                UserName = "nsidorenko@gmail.com",
                PasswordHash = "AKd7l6Ssw0C1mWOWviDxzXYFpWt7/6pNyN0sgEgk3VpNwc3qeWUH83tzktoDIQ2KAg=="
            });
            users.Add(new User
            {
                FirstName = "Dmitry",
                LastName = "Karabanovich",
                BirthDate = new DateTime(1999, 7, 8),
                MainPhoneNumber = "+375(29)444-55-56",
                Email = "dkarabanovich@gmail.com",
                RoleId = roles.First(g => g.Name == "User").RoleId,
                PositionLevelId = positionLevels.First(g => g.Name == "Intern").PositionLevelId,
                PositionId = positions.First(g => g.Name == ".NET Developer").PositionId,
                CategoryId = categories.First(g => g.Name == ".NET Development").CategoryId,
                DepartmentId = departments.First(g => g.Name == "Software Development").DepartmentId,
                UserName = "dkarabanovich@gmail.com",
                PasswordHash = "AKd7l6Ssw0C1mWOWviDxzXYFpWt7/6pNyN0sgEgk3VpNwc3qeWUH83tzktoDIQ2KAg=="

            });

            //roles.ForEach(g => context.Roles.AddOrUpdate(g));
            //departments.ForEach(g => context.Departments.AddOrUpdate(g));
            //categories.ForEach(g => context.Categories.AddOrUpdate(g));
            //positions.ForEach(g => context.Positions.AddOrUpdate(g));
            //positionLevels.ForEach(g => context.PositionLevels.AddOrUpdate(g));
            //users.ForEach(g => context.Users.AddOrUpdate(g));

            context.SaveChanges();
        }
    }
}