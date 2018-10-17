using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredExamDomain;
using WiredExamDomain.Models;

namespace WiredExamServices
{
    public class AccountServices
    {
        BaseClassContext db = new BaseClassContext();
        public UserProfile UserLogin(UserProfile userProfile)
        {

            var userProfileCheck = db.UserProfiles.Where(x => x.userName == userProfile.userName && x.password == userProfile.password).FirstOrDefault();
            return userProfileCheck;
        }
    }
}
