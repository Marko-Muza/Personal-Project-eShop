using DataAccessLayer.Interfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public class GuidForAddProducts: IGuidForAddProducts
    {
        private readonly IProductManager _productManager;
        private readonly ICurrentDate _currentDate;
        private readonly IGuidGenerator _guidGenerator;
        

        public GuidForAddProducts(IProductManager productManager, ICurrentDate currentDate, IGuidGenerator guidGenerator)
        {
            _currentDate = currentDate;
            _productManager = productManager;
            _guidGenerator = guidGenerator;
        }

        public bool GuidForAddProductsMethod(ProductAll newProduct)
        {
            if (newProduct != null)
            {
                newProduct.ProductDetails.DatePublished = _currentDate.GetCurrentDate();
                newProduct.SimpleProduct.Code = _guidGenerator.GetGuid();
                _productManager.AddProduct(newProduct.SimpleProduct, newProduct.ProductDetails);
                return true;
                // call productmanager
            }
            else
            {
                return false;
            }
        }
    }
}
