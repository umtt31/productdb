﻿using AspNetCoreMvc003.Helpers;
using AspNetCoreMvc003.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc003.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private IHelper _helper;

        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context, IHelper helper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _helper = helper;

            /* 
            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 200, Color = "Red"});
                _context.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 300 });
                _context.Products.Add(new Product() { Name = "Kalem 3", Price = 300, Stock = 400 });

                _context.SaveChanges();
            }
            */
        }

        public IActionResult Index(/* [FromServices]IHelper helper2, int id */)
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id); // Primary Key'e gore arama yapiyor
            _context.Products.Remove(product);

            _context.SaveChanges();

            TempData["status"] = "Product deleted successfully...";

            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {

            return View();
        }


        [HttpPost] public IActionResult Add(Product newProduct)
        {
            /*
            var name = HttpContext.Request.Form["Name"].ToString();
            var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            var color = HttpContext.Request.Form["Color"].ToString();
            */

            // Product newProduct = new() { Name = Name, Price = Price, Stock = Stock, Color = Color};

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "Product added successfully...";

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost] public IActionResult Update(Product updatedproduct, int productId)
        {
            updatedproduct.Id = productId;
            _context.Products.Update(updatedproduct);
            _context.SaveChanges();

            TempData["status"] = "Product updated successfully...";

            return RedirectToAction("Index");
        }




    }
}
