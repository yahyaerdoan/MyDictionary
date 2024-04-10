using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.SessionHelper;
using Dictionary.EntityLayer.Concrete;
using PagedList;
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
        private readonly IWriterService _writerService;


		public MyHeaderController(IHeadService headService, ICategoryService categoryService, IWriterService writerService)
		{
			_headService = headService;
			_categoryService = categoryService;
			_writerService = writerService;
		}

        private void GetCategoryNameForDropDownBySelectList()
        {
            ViewBag.CategoryName = new SelectList(_categoryService.TGetAllList(), "CategoryId", "Name");
        }

        public ActionResult Index()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            var values = _headService.TListByFilter(a=> a.WriterId == matchedEmailAndWriterId);
            return View(values);
        }

        public ActionResult AllHeader(int pageIndex = 1)
        {           
            int PageSize = 10;
            var values = _headService.TGetAllList().ToPagedList(pageIndex, PageSize);
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
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
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
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            head.WriterId = matchedEmailAndWriterId;
            head.Date = DateTime.Now;
            head.Status = true;
            _headService.TUpdate(head);
            return RedirectToAction("Index");
        }      
    }
}