using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class ContactAdminController : Controller
    {
        // GET: ContactAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Compose()
        {
            return View();
        }

        public ActionResult ReadMail()
        {
            return View();
        }

        public PartialViewResult FoldersPartial()
        {
            return PartialView();
        }
    }
}