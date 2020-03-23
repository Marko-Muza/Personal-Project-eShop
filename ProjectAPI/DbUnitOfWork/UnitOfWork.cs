using EntityModels;
using System;
using DbRepositories;
using DbRepositories.Interfaces;

namespace DbUnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly eShopContext _context;
        private UserRepository _user;
        private ProductRepository _product;
        private CartRepository _cart;
        private OrderRepository _order;

        public UnitOfWork(eShopContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            _context = context;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }


        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_context);
                }
                return _cart;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_context);
                }
                return _product;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
