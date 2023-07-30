using CvProject.BLL.Abstract;
using CvProject.BLL.Contants;
using CvProject.CORE.Utilities.Result;
using CvProject.DAL.Abstract;
using CvProject.ENTITY.Concrete;
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

        public IDataResult<bool> AddSkill(AddUserSkillDto dto)
        {
            try
            {
                var skill = _userSkillDal.Get(x => x.SkillName == dto.SkillName && x.UserId == dto.UserId);
                if (skill != null)
                {
                    return new ErrorDataResult<bool>(false, "skill_already_exists", Messages.skill_already_exists);
                }

                var newSkill = new UserSkill
                {
                    SkillName = dto.SkillName,
                    SkillStatus = true,
                    SkillProgress = dto.SkillProgress,
                    UserId = dto.UserId,
                };
                _userSkillDal.Add(newSkill);
                return new SuccessDataResult<bool>(true, "added_skill", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
        }

        public IDataResult<bool> DeleteSkill(int id)
        {
            try
            {
                var item = _userSkillDal.Get(x => x.Id == id);

                _userSkillDal.Delete(item);
                return new SuccessDataResult<bool>(true, "skill_deleted", Messages.success);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message, Messages.unk_err);
            }
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
                        SkillProgress = item.SkillProgress,
                        Id = item.Id,
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
