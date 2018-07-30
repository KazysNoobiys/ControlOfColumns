using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ConfigXmlHelper;
using ControlOfColumns.DAL.EF;
using ControlOfColumns.DAL.Models;
using ControlOfColumns.WEB.Models;

namespace ControlOfColumns.WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly ProductDbContext _dbContext;
        public AdminController()
        {
            _dbContext = new ProductDbContext("ProductDbContext");
        }
        [HttpGet]
        public ActionResult Index()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Config/app_config.xml");
            ConfigXmlReader reader = new ConfigXmlReader(path);
            var enabled = reader.ProductEnabled;
            var admin = new ColumnsAdmin()
            {
                NameEnabled = enabled["Name"],
                PriceEnabled = enabled["Price"],
                DescriptionEnabled = enabled["Description"],
                CommnetsEnabled = enabled["Commnets"],
                QuantityEnabled = enabled["Quantity"]
            };
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(ColumnsAdmin admin)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Config/app_config.xml");
            ConfigXmlReader reader = new ConfigXmlReader(path);
            var enabled = reader.ProductEnabled;
            enabled["Name"] = admin.NameEnabled;
            enabled["Price"] = admin.PriceEnabled;
            enabled["Description"] = admin.DescriptionEnabled;
            enabled["Commnets"] = admin.CommnetsEnabled;
            enabled["Quantity"] = admin.QuantityEnabled;
            reader.Save();
            return RedirectToAction("Index","Home");
        }

    }
}