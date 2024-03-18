using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.FluentValidationRules;
using Dictionary.EntityLayer.Concrete;
using FluentValidation.Results;
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
        WriterValidation _writerValidation = new WriterValidation();
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

        [HttpGet]
        public ActionResult CreateWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWriter(Writer writer)
        {
            ValidationResult validationResult = _writerValidation.Validate(writer);
            if (validationResult.IsValid)
            {
                writer.Date = DateTime.Now;
                _writerService.TAdd(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var values= _writerService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            ValidationResult validationResult = _writerValidation.Validate(writer);            
            if (validationResult.IsValid)
            {
                writer.Date = DateTime.Now;
                _writerService.TUpdate(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}