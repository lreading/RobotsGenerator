using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BobotsTxtGenerator.MVC.Controllers
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

        public ActionResult RobotsTxt()
        {
            // Class that contains the methods to generate our robots items.
            BLL.SEOMethods SEOHelper = new BLL.SEOMethods();
            // Get our robots items
            List<RobotsTxtGenerator.RobotsItem> RobotsTxtItems = SEOHelper.GetRobotsTXTItems(this.Url);
            // Return the robots result
            return new RobotsTxtGenerator.RobotsResult(RobotsTxtItems);
        } // end robots txt
    }
}