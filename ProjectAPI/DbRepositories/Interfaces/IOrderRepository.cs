using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepositories.Interfaces
{
    public interface IOrderRepository
    {
        List<EntityModels.Order> GetAllOrders(int id);
    }
}
