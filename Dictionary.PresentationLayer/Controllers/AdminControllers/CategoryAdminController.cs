using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.Concrete;
using Dictionary.BussinessLogicLayer.FluentValidationRules;
using Dictionary.DataAccessLayer.Context;
using Dictionary.EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class CategoryAdminController : Controller
    {
        // GET: CategoryAdmin
        ICategoryService _categoriService;

        public CategoryAdminController(ICategoryService categoriService)
        {
            _categoriService = categoriService;
        }

        //CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidation _categoryValidation = new CategoryValidation();
        public ActionResult Index()
        {
            var values = _categoriService.TGetAllList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            ValidationResult validationResult = _categoryValidation.Validate(category);
            if (validationResult.IsValid)
            {
                _categoriService.TAdd(category);
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

        public ActionResult DeleteCategory(int id)
        {
            //var values = categoryManager.TGetByIdWithFilter(c=> c.CategoryId == id);
            //categoryManager.TDelete(values);
            _categoriService.TDeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = _categoriService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {           
            _categoriService.TUpdate(category);                      
            return RedirectToAction("Index");
        }
    }
}