using DbRepositories.Interfaces;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbRepositories
{
    public class UserRepository: IUserRepository  
    {
        private eShopContext _eShopContext;
        public DbSet<User> _dbSet;                
        public UserRepository(eShopContext context)
        {
            _dbSet = context.User;
            _eShopContext = context;
        }

        // Check If User Exists
        public bool CheckIfUserExists(string username)
        {
            return _dbSet.Any(u => u.Username==username);
        }

        //  Finding a user by Id
        public User GetById(int id)
        {
            return _dbSet.SingleOrDefault(u => u.Id == id); 
        }
        // User Login
        public int Login(string username, string password)
        {
            var searchResult = _dbSet.SingleOrDefault(u => u.Username == username && u.Password == password).Id;
            if (searchResult != 0)
            {
                return searchResult;
            }
            else
            {
                throw new Exception("No users were found");
            }
        }
        // User Registration
        public void Register(User user)
        {
            _dbSet.Add(user);
        }
    }
}
