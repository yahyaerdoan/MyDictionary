using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class GalleryAdminController : Controller
    {
        // GET: GalleryAdmin
        private readonly IGalleryService _galleryService;

        public GalleryAdminController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public ActionResult Index()
        {
           var values = _galleryService.TGetAllList();
            return View(values);
        }
    }
}