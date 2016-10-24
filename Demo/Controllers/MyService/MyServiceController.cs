using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

		public ActionResult MyService(string id) {
			/// Return the web service


			return Json(data, JsonRequestBehavior.AllowGet);
		}

		public ActionResult MyServiceJWSDL {
			/// Return a description of hte service


			return Json(data, JsonRequestBehavior.AllowGet);
		}

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}