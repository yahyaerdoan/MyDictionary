using Dictionary.BussinessLogicLayer.Abstract;
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
        private readonly IContactService _contactService;

        public ContactAdminController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ActionResult Index()
        {
            var values = _contactService.TGetAllList();
            return View(values);
        }

        public ActionResult Compose()
        {
            return View();
        }

        public ActionResult ReadMail(int id)
        {
            var values = _contactService.TGetById(id);
            return View(values);
        }

        public PartialViewResult FoldersPartial()
        {
            return PartialView();
        }
    }
}