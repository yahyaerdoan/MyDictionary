using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyWriterController : Controller
    {
        // GET: MyWriter
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MyProfilePartial()
        {
            return PartialView();
        }

        public PartialViewResult MyAboutMePartial()
        {
            return PartialView();
        }

        public PartialViewResult MyAtsPartial()
        {
            return PartialView();
        }
    }
}