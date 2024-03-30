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
            string sessionForEMail = (string)Session["Email"];
            var matchedSessionAndEMail = _headService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            var values = _headService.TListByFilter(a=> a.WriterId == matchedEmailAndWriterId);
            return View(values);
        }

        public ActionResult AllHeader()
        {
            var values = _headService.TGetAllList();
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
            string sessionForEMail = (string)Session["Email"];
            var matchedSessionAndEMail = _headService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            head.WriterId = matchedEmailAndWriterId;
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
            string sessionForEMail = (string)Session["Email"];
            var matchedSessionAndEMail = _headService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            head.WriterId = matchedEmailAndWriterId;
            head.Date = DateTime.Now;
            head.Status = true;
            _headService.TUpdate(head);
            return RedirectToAction("Index");
        }      
    }
}