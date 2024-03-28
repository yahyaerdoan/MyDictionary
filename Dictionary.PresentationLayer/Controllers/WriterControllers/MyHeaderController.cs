using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyHeaderController : Controller
    {
        // GET: MyHeader
        private readonly IHeadService _headService;
        private readonly ICategoryService _categoryService;

		public MyHeaderController(IHeadService headService, ICategoryService categoryService)
		{
			_headService = headService;
			_categoryService = categoryService;
		}
        private void GetCategoryNameForDropDownBySelectList()
        {
            ViewBag.CategoryName = new SelectList(_categoryService.TGetAllList(), "CategoryId", "Name");
        }
        public ActionResult Index()
        {            
            var values = _headService.TListByFilter(a=> a.WriterId == 7);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateHeader()
        {
            GetCategoryNameForDropDownBySelectList();
            return View();
        }
		[HttpPost]
        public ActionResult CreateHeader(Head head)
        {
            head.WriterId = 7;
            head.Date = DateTime.Now;
            head.Status = true;
            _headService.TAdd(head);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateHeaderAsAFalse(int id)
        {
            var values = _headService.TGetById(id);
            values.Status = false;
            _headService.UpdateAsAFalse(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeader(int id)
        {
            GetCategoryNameForDropDownBySelectList();
            var values = _headService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateHeader(Head head)
        {
            head.WriterId = 7;
            head.Date = DateTime.Now;
            head.Status = true;
            _headService.TUpdate(head);
            return RedirectToAction("Index");
        }
    }
}