﻿using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class HeaderAdminController : Controller
    {
        // GET: Header
        private readonly IHeadService _headService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService  _writerService;

        public HeaderAdminController(IHeadService headService, ICategoryService categoryService, IWriterService writerService)
        {
            _headService = headService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public void GetCategoryNameForDropDownBySelectList()
        {
            ViewBag.CategoryName = new SelectList(_categoryService.TGetAllList(), "CategoryId", "Name");
        }

        public void GetWriterFullNameForDropDownSelectList()
        {
            ViewBag.WriterFullName = new SelectList(from a in _writerService.TGetAllList().ToList()
                                                    select new
                                                    {
                                                        writerId = a.WriterId,
                                                        FullName = a.FirstName + " " + a.LastName
                                                    }, "WriterId", "FullName");
        }

        public ActionResult Index()
        {
            var values = _headService.TGetAllList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateHeader()
        {
            GetCategoryNameForDropDownBySelectList();
            GetWriterFullNameForDropDownSelectList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateHeader(Head head)
        {
            head.Date = DateTime.Now;
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
        public ActionResult UpdateHeaderAsATrue(int id)
        {
            var values = _headService.TGetById(id);
            values.Status = true;
            _headService.UpdateAsATrue(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeader(int id)
        {
            GetCategoryNameForDropDownBySelectList();
            GetWriterFullNameForDropDownSelectList();
            var values = _headService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateHeader(Head head)
        {
            head.Date = DateTime.Now;
            _headService.TUpdate(head);
            return RedirectToAction("Index");
        }
    }
}