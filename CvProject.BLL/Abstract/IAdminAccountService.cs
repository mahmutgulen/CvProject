﻿using CvProject.CORE.Utilities.Result;
using CvProject.ENTITY.Dtos.AdminAccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Abstract
{
    public interface IAdminAccountService
    {
        IDataResult<GetAdminAccountDto> GetAdminAccount(int userId);

        IDataResult<bool> UpdateAdminAccount(UpdateAdminAccountDto dto);

        IDataResult<bool> CreatePdf(int userId);
        IDataResult<bool> DownloadPdf(int userId);
    }
}
