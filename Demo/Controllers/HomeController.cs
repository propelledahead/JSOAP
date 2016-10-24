using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers {
    public class HomeController : Controller {
        
		public ActionResult Index() {
			// Homepage for our main website 

            return View();
        }


    }
}