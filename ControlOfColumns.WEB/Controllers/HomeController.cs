using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ControlOfColumns.DAL.EF;
using ControlOfColumns.DAL.Models;
using ControlOfColumns.WEB.Models;

namespace ControlOfColumns.WEB.Controllers
{
    public class HomeController : Controller
    {
        ProductDbContext _dbContext = new ProductDbContext("ProductDbContext");
        public ActionResult Index()
        {
            var listProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductsViewModels>>(_dbContext.Products);
            return View(listProducts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductsViewModels productsViewModels)
        {
            if (ModelState.IsValid)
            {
                var product = Mapper.Map<ProductsViewModels, Product>(productsViewModels);
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsViewModels);
        }

        [Authorize(Roles = "user")]
        public ActionResult Edit(int id)
        {
            var prod = Mapper.Map<Product, ProductsViewModels>(_dbContext.Products.Find(id));
            if (prod != null)
                return View(prod);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsViewModels productsViewModels)
        {
            if (ModelState.IsValid)
            {
                var product = Mapper.Map<ProductsViewModels, Product>(productsViewModels);
                _dbContext.Products.AddOrUpdate(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsViewModels);
        }

        [Authorize(Roles = "user")]
        public ActionResult Delete(int id)
        {
            var prod = Mapper.Map<Product, ProductsViewModels>(_dbContext.Products.Find(id));
            if (prod != null)
                return View(prod);
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductsViewModels productsViewModels)
        {
            var product = _dbContext.Products.Find(productsViewModels.Id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "user")]
        public ActionResult Details(int id)
        {
            var prod = Mapper.Map<Product, ProductsViewModels>(_dbContext.Products.Find(id));
            if (prod != null)
                return View(prod);
            return RedirectToAction("Index");

        }
    }
}