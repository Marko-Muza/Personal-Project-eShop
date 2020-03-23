using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public interface IUser
    {
        public bool CheckIfUserExists(string username);
    }
}
