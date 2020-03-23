using DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogicLayer
{
    public interface IGuidForAddProducts
    {
        public bool GuidForAddProductsMethod(ProductAll newProduct);
    }
}
