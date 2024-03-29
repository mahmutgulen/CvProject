﻿using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.UserLanguageDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IUserLanguageService
    {
        IDataResult<List<GetUserLanguageDto>> GetUserLanguage(int userId);
        IDataResult<bool> DeleteUserLanguage(int id);
        IDataResult<bool> AddUserLanguage(AddUserLanguageDto dto);
    }
}
