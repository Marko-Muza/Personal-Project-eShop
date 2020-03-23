using System;
using System.Collections.Generic;
using System.Text;
using DbRepositories.Interfaces;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using DbRepositories;
using System.Linq;

namespace DbRepositories
{
    public class CartRepository: ICartRepository
    {
        private eShopContext _ebayCopyDb;
        private DbSet<Cart> _dbSet;
        public CartRepository(eShopContext context)
        {
            _dbSet = context.Cart;
            _ebayCopyDb = context;
        }

        public void CreateCart(Cart cart)
        {
            _dbSet.Add(cart);
        }

        public Cart GetByUserId(int Id)
        {
            try
            {
                return _dbSet.SingleOrDefault(c => c.UserId == Id);
            }
            catch (Exception)
            {

                throw new Exception("Cart not found!");
            }
        }

        public CartProduct GetCartProductById(int id)
        {
            var result = _ebayCopyDb.CartProduct.SingleOrDefault(c => c.Id == id);
            if (result == null)
            {
                throw new Exception("Product not found.");
            }
            return result;
        }

        public void UpdateCartProduct(int id, int cartItemId, int quantity, DateTime date)
        {
            GetCartProductById(cartItemId).Quantity = quantity;
            GetByUserId(id).DateLastUpdated = date;
        }
        public void DeleteCartProduct(int cartItemId)
        {
            try
            {
                _ebayCopyDb.Remove(GetCartProductById(cartItemId));
            }
            catch (Exception)
            {

                throw new Exception("Product not found!");
            }
        }
        // Dole sam zamjenio sve intove u stringove, jer sam u bazi zamjenio int u string za Code !
        public List<string> GetAllCartProductsByCartId(int id)
        {
            var idCart = GetByUserId(id).Id;
            List<CartProduct> cartProductResult;
            List<string> listOfCodes = new List<string>();
            try
            {
                cartProductResult = _ebayCopyDb.CartProduct.Where(c => c.CartId == idCart).ToList();
            }
            catch (Exception)
            {
                throw new Exception("Found no products in cart!");
            }

            if (cartProductResult == null)
            {
                throw new Exception("Found no products in cart!");
            }

            foreach (var cartProduct in cartProductResult)
            {
                listOfCodes.Add(cartProduct.Code);
            }
            return listOfCodes;
        }
    }
}
