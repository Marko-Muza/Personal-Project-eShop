using EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepositories.Interfaces
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        Cart GetByUserId(int Id);
        List<string> GetAllCartProductsByCartId(int id); 
        CartProduct GetCartProductById(int cartItemId);
        void DeleteCartProduct(int cartItemId);
        void UpdateCartProduct(int id, int cartItemId, int quantity, DateTime date);
    }
}




