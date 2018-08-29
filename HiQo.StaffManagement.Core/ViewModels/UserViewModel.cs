﻿using System;
using System.Collections.Generic;

namespace HiQo.StaffManagement.Core.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MainPhoneNumber { get; set; }

        public string Email { get; set; }

        public int CurrentDepartmentId { get; set; }
        public Dictionary<int, string> DictionaryOfDepartments { get; set; }

        public int CurrentCategoryId { get; set; }
        public Dictionary<int, string> DictionaryOfCategories { get; set; }

        public int CurrentPositionId { get; set; }
        public Dictionary<int,string> DictionaryOfPositions { get; set; }
        
        public int CurrentPositionLevelId { get; set; }
        public Dictionary<int, string> DictionaryOfPositionLevels { get; set; }

        public int CurrentRoleId { get; set; }
        public Dictionary<int,string> DictionaryOfRoles { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }
    }
}