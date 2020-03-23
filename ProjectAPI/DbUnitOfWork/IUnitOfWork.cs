using System;
using System.Collections.Generic;
using System.Text;
using EntityModels;
using DbRepositories;
using DbRepositories.Interfaces;

namespace DbUnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ICartRepository Cart { get; }
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        void Commit();
    }
}
