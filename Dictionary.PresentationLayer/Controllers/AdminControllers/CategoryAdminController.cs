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
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidation categoryValidation = new CategoryValidation();
        public ActionResult Index()
        {
            var values = categoryManager.TGetAllList();
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
            ValidationResult validationResult = categoryValidation.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.TAdd(category);
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
            categoryManager.TDeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = categoryManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var values = categoryManager.TGetById(category.CategoryId);
            categoryManager.TUpdate(category);
            values.Name = category.Name;
            values.Description = category.Description;
            values.Status = category.Status;            
            return RedirectToAction("Index");
        }
    }
}