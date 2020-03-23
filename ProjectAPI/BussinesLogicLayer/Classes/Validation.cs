using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public class Validation: IValidation
    {
        // property
        private readonly IUser _user;
        // konstruktor
        public Validation(IUser user)
        {
            _user = user; // inicijalizuje
        }

        // Validate user info at login
        public bool CheckUserExists(DTOs.User user)
        {
            // Check if user sent username and password
            var result = ValidateLoginInput(user.Username, user.Password);
            if (!result || user.Role == 0)
            {
                return false;
            }
            else
            {
                return !(_user.CheckIfUserExists(user.Username));
            }
        }

        // Validate user info for login
        public bool ValidateLoginInput(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return true;
        }

        // Validate product info for Update
        public bool ValidateProductUpdate(Product product, ProductDetails productDetails)
        {
            // Check each property of product and productDetails
            return true;
        }
    }
}
