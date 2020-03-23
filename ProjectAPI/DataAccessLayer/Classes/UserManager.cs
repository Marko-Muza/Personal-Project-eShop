using System;
using System.Collections.Generic;
using System.Text;
using EntityModels;
using System.Linq;
using DTOs;
using DbUnitOfWork;
using AutoMapper;

namespace DataAccessLayer
{
    public class UserManager : IUserManager
    {
        private IMapper _mapper;

        public UserManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Returns a user based on Id
        public DTOs.User GetUser(int id)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EntityModels.User efUser = uow.User.GetById(id);
                if (efUser is null)
                    return null;

                DTOs.User user = _mapper.Map<DTOs.User>(efUser);

                return user;
            }
        }
        // Check if user already exists (For registration)
        public bool CheckIfUserExists(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("User info was not provided!");
            }

            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                return uow.User.CheckIfUserExists(username);
            }
        }

        // User Registration
        public int RegisterUser(DTOs.User loginUser, DateTime lastUpdated)
        {
            if (loginUser == null)
            {
                throw new ArgumentNullException("User info was not provided!");
            }
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                EntityModels.User user = _mapper.Map<EntityModels.User>(loginUser);
                uow.User.Register(user);

                // Creating mapping 
                EntityModels.Cart cart = new EntityModels.Cart() { DateLastUpdated = lastUpdated };
                // and adding the cart to the user
                user.Cart.Add(cart);

                uow.Commit();

                return user.Id;

            }
        }

       
        // Login
        public int LoginUser(string username, string password)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                try
                {
                    return uow.User.Login(username, password);

                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        // Add Product to Cart
        public void AddToCart(int id, DTOs.CartProduct cartProduct, DateTime date)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EntityModels.CartProduct newCartProduct = new EntityModels.CartProduct { Code = cartProduct.Code, Quantity = cartProduct.Quantity };
                uow.Cart.GetByUserId(id).CartProduct.Add(newCartProduct); // Poziva metodu GetById iz CartRepository i dodaje novi produkt i datum
                uow.Cart.GetByUserId(id).DateLastUpdated = date;          
                uow.Commit();
            }
        }
        // Cart Update metod
        public void UpdateCart(int id, int idCartProduct, int quantity, DateTime date)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                uow.Cart.UpdateCartProduct(id, idCartProduct, quantity, date); // Poziva metodu iz CartRepositoryja
                uow.Commit();
            }
        }
        // Delete Products from Cart
        public void DeleteFromCart(int id, int idCartProduct, DateTime date)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                uow.Cart.DeleteCartProduct(idCartProduct);
                uow.Cart.GetByUserId(id).DateLastUpdated = date;

                uow.Commit();
            }
        }
        // Return all products from cart
        public Products GetAllCartProduct(int id)
        {
            using (eShopContext context = new eShopContext())
            {
                var allCartCode = new List<string>();
                Products listOfDTOProducts = new Products() { ArrayOfProducts = new List<DTOs.Product>() };
                UnitOfWork uow = new UnitOfWork(context);
                try
                {
                    allCartCode = uow.Cart.GetAllCartProductsByCartId(id);
                    var entityProductsList = uow.Product.GetProductsByCode(allCartCode);
                    foreach (var entityProduct in entityProductsList)
                    {
                        listOfDTOProducts.ArrayOfProducts.Add(_mapper.Map<DTOs.Product>(entityProduct));
                    }
                    return listOfDTOProducts;
                }
                catch (Exception)
                {
                    return new Products() { ArrayOfProducts = new List<DTOs.Product>() };
                }
            }
        }
    }

}
