using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbRepositories.Interfaces;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace DbRepositories
{
    public class ProductRepository: IProductRepository
    {
        private eShopContext eShopDb;
        private DbSet<Product> _dbSet;
        public ProductRepository(eShopContext context)
        {
            _dbSet = context.Product;
            eShopDb = context;
        }


        // Add Product
        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product was not provided!");
            }
            eShopDb.Product.Add(product);
        }
        // Delete product
        public bool DeleteProduct(string code)
        {
            // Check if product exists and return it
            var product = GetProductByCode(code);
            if (product != null)
            {
                product.IsActive = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        // Get Product By Id
        public EntityModels.Product GetById(object id)
        {
            return _dbSet.SingleOrDefault(s => s.Id == (int)id);
        }
        // Get product and productDetails based on id
        public EntityModels.Product GetFullProductById(int id)
        {
            return _dbSet.Include("ProductDetails.Product").SingleOrDefault(p => p.Id == id);
        }
       
        // Get a single product by code
        public Product GetProductByCode(string code)
        { 
            return _dbSet.SingleOrDefault(p => p.Code == code && p.IsActive == true);
        }
        // Get All Product By Code
        public List<Product> GetProductsByCode(List<string> codes)
        {
            List<Product> listOfProducts = new List<Product>();

            listOfProducts = _dbSet.Where(p => codes.Contains(p.Code) && p.IsActive == true).ToList();

            if (listOfProducts == null)
            {
                throw new Exception("No products found!");
            }
            return listOfProducts;
        }
        // Get all products based on search query, filter and category
        public List<EntityModels.Product> GetBySearch(DTOs.SearchBy searchBy)
        {
            var query = eShopDb.Product.AsQueryable();

            if (searchBy.Search != null)
            {
                query = query.Where(p => p.Name.Contains(searchBy.Search));
            }
            if (searchBy.Category > 0)
            {
                query = query.Where(p => p.ProductDetails.SingleOrDefault().Model == (int)searchBy.Category);
            }
            if (searchBy.Gender > 0)
            {
                query = query.Where(p => p.ProductDetails.SingleOrDefault().Gender == (int)searchBy.Gender);
            }
            if (searchBy.Condition > 0)
            {
                query = query.Where(p => p.ProductDetails.SingleOrDefault().Condition == (int)searchBy.Condition);
            }
            if (searchBy.FreeShipping == true)
            {
                query = query.Where(p => p.ShippingPrice == 0);
            }
            if (searchBy.PriceRange.FromPrice > 0 && searchBy.PriceRange.ToPrice > 0)
            {
                query = query.Where(p => p.Price > (decimal)searchBy.PriceRange.FromPrice && p.Price < (decimal)searchBy.PriceRange.ToPrice);
            }
            return query.AsNoTracking().OrderBy(p => p.Name).ToList();
        }
        /*
        // Check if products exists based on id
        public bool CheckIfProductExists(int id)
        {
            return eShopDb.Product.Any(p => p.Id == id && p.IsActive == true);
        }

        // Check if product is active and in stock
        public bool CheckIfProductIsActiveAndInStock(int id, int quantity)
        {
            return eShopDb.Product.Any(p => p.Id == id && p.IsActive == true && p.InStock > quantity);
        }*/

    }
}
