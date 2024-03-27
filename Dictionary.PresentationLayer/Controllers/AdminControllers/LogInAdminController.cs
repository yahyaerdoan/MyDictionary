using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class LogInAdminController : Controller
    {
        // GET: LogInAdmin
        private readonly IAdminService _adminService;

		public LogInAdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = _adminService.TGetByIdWithFilter(a => a.UserName == admin.UserName && a.Password == admin.Password);
			if (values != null)
			{
                return RedirectToAction("Index", "CategoryAdmin");
			}
			else
			{
                return View("Kullanici adi veya sifre hatali");
            }           
        }
    }
}