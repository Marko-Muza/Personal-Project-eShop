using AutoMapper;
//using Mapper;
using DataAccessLayer.Interfaces;
using DbUnitOfWork;
using DTOs;
using EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Classes
{
    public class ProductManager : IProductManager
    {
        private IMapper _mapper;
           
        public ProductManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Returns based on search query (name, filters, category)
        public DTOs.Products GetProducts(SearchBy searchBy)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);

                DTOs.Products listOfProducts = new Products() { ArrayOfProducts = new List<DTOs.Product>() };

                List<EntityModels.Product> searchResultProduct = uow.Product.GetBySearch(searchBy);

                foreach (var product in searchResultProduct)
                {
                    listOfProducts.ArrayOfProducts.Add(_mapper.Map<DTOs.Product>(product));
                }

                //EntityModels.ProductDetails productDetails = uow.ProductDetails.Query(d => d.Model == category){ }
                return listOfProducts;
            }
        }

        // Returns full product (product, productDetails) based on product id
        public DTOs.ProductAll GetProduct(int id)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                DTOs.ProductAll productAll = new ProductAll();

                var fullProductEntity = uow.Product.GetFullProductById(id);
                var productDetailEntity = fullProductEntity.ProductDetails.SingleOrDefault();
                if (fullProductEntity == null)
                {
                    return productAll;
                }

                productAll.SimpleProduct = _mapper.Map<DTOs.Product>(fullProductEntity);
                productAll.ProductDetails = _mapper.Map<DTOs.ProductDetails>(productDetailEntity);

                return productAll;
            }
        }

        // Add a new product
        public void AddProduct(DTOs.Product product, DTOs.ProductDetails productDetails)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EntityModels.Product productEntity = _mapper.Map<EntityModels.Product>(product);
                EntityModels.ProductDetails productDetailsEntity = _mapper.Map<EntityModels.ProductDetails>(productDetails);

                uow.Product.AddProduct(productEntity);
                productEntity.ProductDetails.Add(productDetailsEntity);

                uow.Commit();
            }
        }

        // Update an existing product
        public bool UpdateProduct(DTOs.Product product, DTOs.ProductDetails productDetails)
        {
            using (eShopContext context = new eShopContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                EntityModels.Product productEntity = _mapper.Map<EntityModels.Product>(product);
                EntityModels.ProductDetails productDetailsEntity = _mapper.Map<EntityModels.ProductDetails>(productDetails);

                // Check if product exists
                var resultOfProductSearch = uow.Product.GetProductByCode(product.Code);
                if (resultOfProductSearch != null)
                {
                    resultOfProductSearch.IsActive = false;
                    uow.Product.AddProduct(productEntity);
                    productEntity.ProductDetails.Add(productDetailsEntity);

                    uow.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Delete product
        public bool DeleteProduct(string code)
        {
            if (code != null)
            {
                using (eShopContext context = new eShopContext())
                {
                    UnitOfWork uow = new UnitOfWork(context);
                    var resultOfProductDelete = uow.Product.DeleteProduct(code);
                    if (resultOfProductDelete)
                    {
                        uow.Commit();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
