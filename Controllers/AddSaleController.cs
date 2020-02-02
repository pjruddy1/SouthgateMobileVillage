using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SouthgateMobileVillage.Models;

namespace SouthgateMobileVillage.Controllers
{
    public class AddSaleController : Controller
    {
        // GET: AddSale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddHome4Sale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHome4Sale(double price, int bathroom, int bedroom, int year, int lot, string model, string description, int sqrFeet)
        {
            Home4Sale home4Sale = new Home4Sale()
            {
                Price = price,
                Bathroom = bathroom,
                Bedroom = bedroom,
                Year = year,
                Lot = lot,
                Model = model,
                Description = description,
                SqrFeet = sqrFeet
            };

            return View("Home4SaleConfirm", home4Sale);
        }
    }
}