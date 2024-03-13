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
            categoryManager.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}