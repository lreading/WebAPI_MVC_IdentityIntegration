using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult _Getvalues()
        {
            BLL.RestWrapper RestHelper = new BLL.RestWrapper();
            var values = RestHelper.GetValues();

            return Json(values, JsonRequestBehavior.AllowGet);
        } // end get values
    }
}