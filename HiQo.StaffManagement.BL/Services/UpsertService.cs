using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.BL.Services
{
    public class UpsertService : IUpsertService
    {
        private readonly ICategoryService _categoryService;
        private readonly IDepartmentService _departmentService;
        private readonly IPositionLevelService _positionLevelService;
        private readonly IPositionService _positionService;
        private readonly IRoleService _roleService;

        public UpsertService(IDepartmentService departmentService,
            ICategoryService categoryService, IPositionService positionService,
            IPositionLevelService positionLevelService, IRoleService roleService)
        {
            _departmentService = departmentService;
            _categoryService = categoryService;
            _positionService = positionService;
            _positionLevelService = positionLevelService;
            _roleService = roleService;
        }

        public Dictionary<int,string> getDictionaryNameByIdDepartment()
        {
            return _departmentService.NameByIdDictionary();
        }

        public Dictionary<int, string> getDictionaryNameByIdCategory()
        {
            return _categoryService.NameByIdDictionary();
        }

        public Dictionary<int, string> getDictionaryNameByIdPosition()
        {
            return _positionService.NameByIdDictionary();
        }

        public Dictionary<int, string> getDictionaryNameByIdPositionLevel()
        {
            return _positionLevelService.NameByIdDictionary();
        }

        public Dictionary<int, string> getDictionaryNameByIdRole()
        {
            return _roleService.NameByIdDictionary();
        }

    }
}