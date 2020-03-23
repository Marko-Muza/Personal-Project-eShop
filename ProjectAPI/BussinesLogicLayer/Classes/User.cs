
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public class User : IUser
    {
        private IUserManager _userManager;
        public User(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public bool CheckIfUserExists(string username)
        {
            return _userManager.CheckIfUserExists(username);
        }
    }
}
