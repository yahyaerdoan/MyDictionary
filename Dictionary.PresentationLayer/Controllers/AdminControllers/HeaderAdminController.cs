using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class HeaderAdminController : Controller
    {
        // GET: Header
        private readonly IHeadService _headService;

        public HeaderAdminController(IHeadService headService)
        {
            _headService = headService;
        }

        public ActionResult Index()
        {
            var values = _headService.TGetAllList();
            return View(values);
        }
    }
}