using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class ContentAdminController : Controller
    {
        // GET: ContentAdmin
        private readonly IContentService _contentSevice;
        private readonly ICategoryService _categoryService;

        public ContentAdminController(IContentService contentSevice, ICategoryService categoryService)
        {
            _contentSevice = contentSevice;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var values = _contentSevice.TGetAllList();
            return View(values);
        }
        public ActionResult ContentByHeader(int id)
        {
            var values = _contentSevice.TGetContentByHeaderId(id);
            return View(values);
        }
        public ActionResult ContentByCategory(int id)
        {
            var values = _contentSevice.TGetContentByCategoryId(id);
            return View(values);
        }
    }
}