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

            roles.Add(new Role {Name = "User", Id = 1});
            roles.Add(new Role {Name = "Admin", Id = 2});
            roles.Add(new Role {Name = "SuperAdmin", Id = 3});

            departments.Add(new Department {Name = "Resource Management", Id = 1});
            departments.Add(new Department {Name = "Software Development", Id = 2});
            departments.Add(new Department {Name = "Quality Assurance", Id = 3});
            departments.Add(new Department {Name = "Business Analysis", Id = 4});

            categories.Add(new Category
            {
                Name = "Administration staff",
                DepartmentId = departments.First(g => g.Name == "Resource Management").Id,
                Id = 1
            });
            categories.Add(new Category
            {
                Name = "Management",
                DepartmentId = departments.First(g => g.Name == "Resource Management").Id,
                Id = 2
            });
            categories.Add(new Category
            {
                Name = ".NET Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").Id,
                Id = 3
            });
            categories.Add(new Category
            {
                Name = "Java Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").Id,
                Id = 4
            });
            categories.Add(new Category
            {
                Name = "Python Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").Id,
                Id = 5
            });
            categories.Add(new Category
            {
                Name = "Front-End Development",
                DepartmentId = departments.First(g => g.Name == "Software Development").Id,
                Id = 6
            });
            categories.Add(new Category
            {
                Name = "Quality Assurance",
                DepartmentId = departments.First(g => g.Name == "Quality Assurance").Id,
                Id = 7
            });
            categories.Add(new Category
            {
                Name = "Business Analysis",
                DepartmentId = departments.First(g => g.Name == "Business Analysis").Id,
                Id = 8
            });

            positions.Add(new Position
            {
                Name = "English Teacher",
                CategoryId = categories.First(g => g.Name == "Administration staff").Id,
                Id = 1
            });
            positions.Add(new Position
            {
                Name = "Human Resource Manager",
                CategoryId = categories.First(g => g.Name == "Administration staff").Id,
                Id = 2
            });
            positions.Add(new Position
            {
                Name = "Accountant",
                CategoryId = categories.First(g => g.Name == "Administration staff").Id,
                Id = 3
            });
            positions.Add(new Position
            {
                Name = "Chief Executive Officer",
                CategoryId = categories.First(g => g.Name == "Management").Id,
                Id = 4
            });
            positions.Add(new Position
            {
                Name = "Director of Delivery",
                CategoryId = categories.First(g => g.Name == "Management").Id,
                Id = 5
            });
            positions.Add(new Position
            {
                Name = ".NET Developer",
                CategoryId = categories.First(g => g.Name == ".NET Development").Id,
                Id = 6
            });
            positions.Add(new Position
            {
                Name = "Java Developer",
                CategoryId = categories.First(g => g.Name == "Java Development").Id,
                Id = 7
            });
            positions.Add(new Position
            {
                Name = "Python Developer",
                CategoryId = categories.First(g => g.Name == "Python Development").Id,
                Id = 8
            });
            positions.Add(new Position
            {
                Name = "Front-End Developer",
                CategoryId = categories.First(g => g.Name == "Front-End Development").Id,
                Id = 9
            });
            positions.Add(new Position
            {
                Name = "QA Engineer",
                CategoryId = categories.First(g => g.Name == "Quality Assurance").Id,
                Id = 10
            });
            positions.Add(new Position
            {
                Name = "Business analyst",
                CategoryId = categories.First(g => g.Name == "Business Analysis").Id,
                Id = 11
            });

            positionLevels.Add(new PositionLevel {Name = "Intern", Level = null, Id = 1});
            positionLevels.Add(new PositionLevel {Name = "Junior", Level = 0, Id = 2});
            positionLevels.Add(new PositionLevel {Name = "Junior", Level = 1, Id = 3});
            positionLevels.Add(new PositionLevel {Name = "Junior", Level = 2, Id = 4});
            positionLevels.Add(new PositionLevel {Name = "Staff", Level = 0, Id = 5});
            positionLevels.Add(new PositionLevel {Name = "Staff", Level = 1, Id = 6});
            positionLevels.Add(new PositionLevel {Name = "Staff", Level = 2, Id = 7});
            positionLevels.Add(new PositionLevel {Name = "Senior", Level = 0, Id = 8});
            positionLevels.Add(new PositionLevel {Name = "Senior", Level = 1, Id = 9});
            positionLevels.Add(new PositionLevel {Name = "Senior", Level = 2, Id = 10});

            users.Add(new User
            {
                Id = 1,
                FirstName = "Kirill",
                LastName = "Dudkov",
                BirthDate = new DateTime(1997, 10, 21),
                MainPhoneNumber = "+375445353430",
                Email = "kirilldudkov@gmail.com",
                RoleId = roles.First(g => g.Name == "User").Id,
                PositionLevelId = positions.First(g => g.Name == "Intern").Id,
                PositionId = positions.First(g => g.Name == ".NET Developer").Id,
                CategoryId = categories.First(g => g.Name == ".NET Development").Id,
                DepartmentId = departments.First(g => g.Name == "Software Development").Id
            });
            users.Add(new User
            {
                Id = 2,
                FirstName = "Nikolay",
                LastName = "Sidorenko",
                BirthDate = new DateTime(1999, 5, 20),
                MainPhoneNumber = "+375291112223",
                Email = "nsidorenko@gmail.com",
                RoleId = roles.First(g => g.Name == "User").Id,
                PositionLevelId = positions.First(g => g.Name == "Intern").Id,
                PositionId = positions.First(g => g.Name == ".NET Developer").Id,
                CategoryId = categories.First(g => g.Name == ".NET Development").Id,
                DepartmentId = departments.First(g => g.Name == "Software Development").Id
            });
            users.Add(new User
            {
                Id = 3,
                FirstName = "Dmitry",
                LastName = "Karabanovich",
                BirthDate = new DateTime(1999, 7, 8),
                MainPhoneNumber = "+375294445556",
                Email = "dkarabanovich@gmail.com",
                RoleId = roles.First(g => g.Name == "User").Id,
                PositionLevelId = positions.First(g => g.Name == "Intern").Id,
                PositionId = positions.First(g => g.Name == ".NET Developer").Id,
                CategoryId = categories.First(g => g.Name == ".NET Development").Id,
                DepartmentId = departments.First(g => g.Name == "Software Development").Id
            });

            roles.ForEach(g => context.Roles.AddOrUpdate(g));
            departments.ForEach(g => context.Departments.AddOrUpdate(g));
            categories.ForEach(g => context.Categories.AddOrUpdate(g));
            positions.ForEach(g => context.Positions.AddOrUpdate(g));
            positionLevels.ForEach(g => context.PositionLevels.AddOrUpdate(g));
            users.ForEach(g => context.Users.AddOrUpdate(g));

            context.SaveChanges();
        }
    }
}