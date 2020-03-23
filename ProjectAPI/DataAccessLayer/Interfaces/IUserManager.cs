
using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IUserManager
    {
        DTOs.User GetUser(int id);
        int LoginUser(string username, string password);
        int RegisterUser(DTOs.User loginUser, DateTime lastUpdated);
        bool CheckIfUserExists(string username);
        Products GetAllCartProduct(int id);
        void AddToCart(int id, CartProduct cartProduct, DateTime date);
        void UpdateCart(int id, int idCartProduct, int quantity, DateTime date);
        void DeleteFromCart(int id, int idCartProduct, DateTime date);
    }
}
