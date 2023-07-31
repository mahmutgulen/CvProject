using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvProject.BLL.Contants
{
    public static class Messages
    {
        #region ProjectLevel
        public static string unk_err = "unk_err";
        public static string success = "success";
        public static string not_found = "not_found";
        #endregion
        #region Register
        public static string user_name_already_exists = "user_name_already_exists";

        public static string password_must_be_same = "password_must_be_same";
        #endregion
        #region Address
        public static string address_added = "address_added";
        public static string address_updated = "address_updated";
        #endregion
        #region Password
        public static string new_password_must_not_be_same_oldpassword = "new_password_must_not_be_same_oldpassword";
        public static string passwords_must_be_same = "passwords_must_be_same";
        public static string oldpassword_is_wrong = "oldpassword_is_wrong";
        #endregion
        #region SocialMedia
        public static string maximum_of_4_social_media_can_be_added = "maximum_of_4_social_media_can_be_added";
        public static string social_media_already_exists = "social_media_already_exists";
        #endregion
        #region Reference
        public static string reference_already_exists = "reference_already_exists";

        #endregion
        #region Skill
        public static string skill_already_exists = "skill_already_exists";
        #endregion
        #region Language
        public static string language_already_exits = "language_already_exits";
        #endregion


    }
}
