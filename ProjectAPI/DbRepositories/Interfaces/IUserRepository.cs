using EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepositories.Interfaces
{
    public interface IUserRepository
    {
        bool CheckIfUserExists(string username);
        int Login(string username, string password);
        void Register(User user);
        EntityModels.User GetById(int id);
    }
}
