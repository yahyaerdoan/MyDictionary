using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyProfileController : Controller
    {
        // GET: WriterProfile
        public ActionResult Index()
        {
            return View();
        }
    }
}