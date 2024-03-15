using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class WriterAdminController : Controller
    {
        // GET: WriterAdmin
        private readonly IWriterService _writerService;

        public WriterAdminController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var values = _writerService.TGetAllList();
            return View(values);
        }
    }
}