using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public interface IValidation
    {
        bool CheckUserExists(DTOs.User user);
        bool ValidateLoginInput(string username, string password);
        bool ValidateProductUpdate(Product product, ProductDetails productDetails);
    }
}
