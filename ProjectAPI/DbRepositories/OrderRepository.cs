using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbRepositories.Interfaces;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories
{
    public class OrderRepository: IOrderRepository
    {
        private DbSet<Order> _dbSet;
        public OrderRepository(eShopContext context)
        {
            _dbSet = context.Order;
        }

        // Return list of orders based on user id
        public List<Order> GetAllOrders(int id)
        {
            if (id != 0)
            {
                return _dbSet.Include("OrderProduct.Order").Where(p => p.UserId == id).ToList();
            }
            else
            {
                return new List<Order>();
            }
        }
    }
}
