using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Dtos.UserSkillDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Concrete
{
    public class UserSkillManager : IUserSkillService
    {
        private readonly IUserSkillDal _userSkillDal;

        public UserSkillManager(IUserSkillDal userSkillDal)
        {
            _userSkillDal = userSkillDal;
        }

        public IDataResult<List<GetUserSkillDto>> GetUserSkill(int userId)
        {
            try
            {
                var userSkills = _userSkillDal.GetAll(x => x.UserId == userId).ToList();
                if (userSkills.Count == 0 || userSkills == null)
                {
                    return new ErrorDataResult<List<GetUserSkillDto>>(new List<GetUserSkillDto>(), "not_found", Messages.not_found);
                }
                var list = new List<GetUserSkillDto>();

                foreach (var item in userSkills)
                {
                    list.Add(new GetUserSkillDto
                    {
                        SkillName = item.SkillName,
                        SkillProgress = item.SkillProgress
                    });
                }

                return new SuccessDataResult<List<GetUserSkillDto>>(list, "success", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<GetUserSkillDto>>(new List<GetUserSkillDto>(), e.Message, Messages.unk_err);
            }
        }
    }
}
