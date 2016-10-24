using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Mvc;
using JSOAP;

namespace Demo.Controllers {
    public class HomeController : Controller {
		public ActionResult Index() {
			/// Return a friendly HTML document describing the Service
			/// We should point to the service and JWSDL as Well
			/// We should also have a change log here and a reference to to consumer
			/// for how our folder versioning works.
			return View();
		}

		public ActionResult MyService(string id) {
			/// Return the web service
			Hashtable data = new Hashtable();
			JWSE oJWSE = new JWSE();

			oJWSE.ServiceVersion = "1.0";
			oJWSE.ServiceURI = "/MyService/1.0/MyService";
			oJWSE.Message = "This is just a demo";
			oJWSE.ResponseCode = 202;

			data.Add ("Hello","World");

			return Json(oJWSE.EnvelopeObjectGet(data), JsonRequestBehavior.AllowGet);
		}



		public ActionResult JWSDL() {
			/// Return a description of hte service
			Hashtable data = new Hashtable();

			JWSDL oJWSDL = new JWSDL();

			return Json(data, JsonRequestBehavior.AllowGet);
		}
    }
}