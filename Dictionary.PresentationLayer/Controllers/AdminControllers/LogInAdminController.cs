using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    [AllowAnonymous]
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
            var values = _adminService.TGetByIdWithFilter(a => a.Email == admin.Email && a.Password == admin.Password);
			if (values != null)
			{
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["Email"] = values.Email;
                return RedirectToAction("Index", "CategoryAdmin");
			}
			else
			{
                return RedirectToAction("Index", "LogInAdmin");
            }           
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HeaderList", "Header");
        }
    }
}