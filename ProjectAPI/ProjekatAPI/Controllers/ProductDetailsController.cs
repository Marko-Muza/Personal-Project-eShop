using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjekatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        /*
        // GET: ProductDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductDetails/Create
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

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductDetails/Edit/5
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

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductDetails/Delete/5
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
        //GET: api/detailedProduct/5
        [HttpGet("{id}")]
        public ActionResult<ProductAll> GetProductDetails(int id)
        {
            return Ok("Get product details with id " + id);
        }

        //POST: api/detailedProduct       ONLY FOR ADMIN
        [HttpPost]
        public ActionResult PostProductDetails([FromBody] ProductAll product)
        {
            // Needs Authentification and autherization
            return Ok("Post product details.");
        }

        //PUT: api/detailedProduct/5         ONLY FOR ADMIN
        [HttpPut("{id}")]
        public ActionResult PutProductDetails(int id, [FromBody] ProductAll product)
        {
            // NEEDS: Authentification and autherization
            return Ok("Put product details.");

        }
        //DELETE: api/detailedProduct/5      ONLY FOR ADMIN
        [HttpDelete("{id}")]
        public ActionResult DeleteProductDetails(int id)
        {
            // NEEDS: Authentification and autherization
            return Ok("Delete product details.");
        }
    }
}