using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Services.Svcs
{
    public class UserService : IUser
    { 
        private IEnumerable<User> GetUserInfos()
        {
            return new List<User>()
            {
                new User()
                {
                    UserId = "test",
                    UserName = "테스터",
                    UserEmail = "test@gmail.com",
                    UserPw = "test",
                }
            };
        }

        private bool CheckUserInfo(string userId, string userPw)
        {
            return GetUserInfos().Any(user => user.UserId == userId && user.UserPw == userPw);
        }

        public bool MatchUserInfo(LoginInfo loginInfo)
        {
            return CheckUserInfo(loginInfo.UserID, loginInfo.UserPW);
        }
    }
}
