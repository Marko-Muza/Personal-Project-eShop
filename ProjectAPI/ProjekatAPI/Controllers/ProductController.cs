using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogicLayer;
using DataAccessLayer.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        /*
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
       
        private readonly IProductManager _productManager;
        private readonly ICurrentDate _currentDate;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IValidation _validation;
        private readonly IGuidForAddProducts _guidForAddProducts;

        public ProductController(IProductManager productManager, ICurrentDate currentDate, IGuidGenerator guidGenerator, IValidation validation, IGuidForAddProducts guidForAddProducts)
        {
            _productManager = productManager;
            _validation = validation;
            _currentDate = currentDate;
            _guidGenerator = guidGenerator;
            _guidForAddProducts = guidForAddProducts;
        }

        //GET: api/product
        [HttpGet]
        public ActionResult<Products> GetProducts(string searchQuery, int category, int gender, int condition, int fromPrice, int toPrice, bool freeShipping )
        {
            // Return all products
            var searchBy = new SearchBy() { Search = searchQuery, Category = (FiltersSortBy.Categories)category, Condition = (FiltersSortBy.Conditions)condition, PriceRange = { FromPrice = fromPrice, ToPrice = toPrice }, Gender = (FiltersSortBy.Genders)gender, FreeShipping = freeShipping };
            var result = _productManager.GetProducts(searchBy);
            return result;

        }

        // Add a new product          
        //POST: api/product
        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductAll newProduct)
        {
            if (newProduct != null)
            {
                var result = _guidForAddProducts.GuidForAddProductsMethod(newProduct); // Method from BLL
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
                // call productmanager
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/product/5/history
        [HttpGet("{id}/history")]
        public ActionResult<Product> GetProductHistory(int id)
        {
            return Ok("Return product history for product with id " + id);
        }

    }
}