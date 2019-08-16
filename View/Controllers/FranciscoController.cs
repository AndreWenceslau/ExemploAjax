using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class FranciscoController : Controller
    {
        // GET: Francisco
        [Route("asas")]
        public ActionResult Index()
        {
            return Json(new { status = "asasas" }, JsonRequestBehavior.AllowGet);
        }
    }
}