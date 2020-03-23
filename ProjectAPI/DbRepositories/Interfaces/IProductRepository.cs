using DTOs;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepositories.Interfaces
{
    public interface IProductRepository
    {
        EntityModels.Product GetById(object id);
        List<EntityModels.Product> GetBySearch(SearchBy searchBy);
        EntityModels.Product GetFullProductById(int id);
        List<EntityModels.Product> GetProductsByCode(List<string> code);
        void AddProduct(EntityModels.Product product);
        EntityModels.Product GetProductByCode(string code);
        bool DeleteProduct(string code);
    }
}
