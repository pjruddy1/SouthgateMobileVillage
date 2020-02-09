using SouthgateMobileVillage.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SouthgateMobileVillage.Models;

namespace SouthgateMobileVillage.Controllers
{
    
    public class HomeController : Controller
    {

        private ResidentContext db = new ResidentContext();

        public ActionResult Index()
        {
            List<Home> homes = db.Homes.ToList();
            List<Graphic> graphics = db.Graphics.ToList();
            var query = from h in homes
                        join gr in graphics on h.ID equals gr.HomeID into table1
                        from gr in table1.DefaultIfEmpty()
                        select new JoinTable { GetHome = h, GetGraphic = gr };
                       

            return View(query.ToList()) ;
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
    }
}