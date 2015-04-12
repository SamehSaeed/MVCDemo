using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string id, string name)
        {
            ViewData["MyName"] = new List<string>() 
            { 
                "Sameh",
                "Saeed",
                "Mohammad",
                "Morsy"
            };

            return View();
        }

    }
}
