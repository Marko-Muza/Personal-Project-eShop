using System;
using System.Collections.Generic;
using System.Text;
using DTOs;

namespace DataAccessLayer.Interfaces
{
    public interface IProductManager
    {
        Products GetProducts(SearchBy searchBy);
        void AddProduct(DTOs.Product product, DTOs.ProductDetails productDetails);
        bool UpdateProduct(DTOs.Product product, DTOs.ProductDetails productDetails);
        bool DeleteProduct(string code);
        DTOs.ProductAll GetProduct(int id);
    }
}
