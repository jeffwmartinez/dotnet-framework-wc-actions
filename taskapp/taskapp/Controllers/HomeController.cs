using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace taskapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Key vault value = " + ConfigurationManager.ConnectionStrings["AZURECONSTRING"];
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}