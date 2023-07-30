﻿using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserEducationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserEducationService
    {
        IDataResult<List<GetUserEducationDto>> GetUserEducation(int userId);
        IDataResult<GetUserEducationDto> GetByIdUserEducation(int id);

        IDataResult<bool> AddEducation(AddUserEducationDto dto);

        IDataResult<bool> UpdateEducation(UpdateUserEducationDto dto);
        IDataResult<bool> DeleteEducation(int id);
    }
}
