using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyLogInController : Controller
    {
        // GET: MyLogIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {

            return View();
        }
    }
}