using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
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
        public PartialViewResult AdminSideBarPartial()
        {
            string sessionForUserName = (string)Session["Email"];
            var values = _adminService.TListByFilter(a => a.Email == sessionForUserName);
            return PartialView(values);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            _adminService.TAdd(admin);            
            return RedirectToAction("Index","Admin");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            GetRoleList();
            var values = _adminService.TGetById(id);
            
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {          
            _adminService.TUpdate(admin);
;            return RedirectToAction("Index", "Admin");
        }

        public void GetRoleList()
        {
            ViewBag.RoleName = new SelectList(_adminService.TGetAllList(), "AdminId","Role");
        }
    }
}