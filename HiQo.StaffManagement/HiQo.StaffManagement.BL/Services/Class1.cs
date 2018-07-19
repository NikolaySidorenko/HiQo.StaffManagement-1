using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;

namespace HiQo.StaffManagement.BL.Services
{
    public class Class1
    {
        private readonly IPositionLevelRepository _positionLevelRepository;

        public Class1(IPositionLevelRepository positionLevelRepository)
        {
            _positionLevelRepository = positionLevelRepository;
        }

        public void Get()
        {
        //    _positionLevelRepository.Add(new PositionLevel());
        }
    }
}
