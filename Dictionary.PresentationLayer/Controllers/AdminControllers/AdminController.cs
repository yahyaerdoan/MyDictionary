using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public ActionResult Index()
        {
            var values = _adminService.TGetAllList();
            return View(values);
        }     
    }
}