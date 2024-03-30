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
        IContentService _contentService;
        
        public CategoryAdminController(ICategoryService categoriService, IContentService contentService)
        {
            _categoriService = categoriService;
            _contentService = contentService;
        }

        //CategoryManager _categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidation _categoryValidation = new CategoryValidation();       
        public ActionResult Index()
        {
            var values = _categoriService.TGetAllList();
            return View(values);
        }

        [HttpGet]
        //[Authorize(Roles = "A")]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
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
            var values = _categoriService.TGetByIdWithFilter(c => c.CategoryId == id);
            _categoriService.TDelete(values);          
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = _categoriService.TGetById(id);
            return View(values);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateCategory(Category category)
        {           
            _categoriService.TUpdate(category);                      
            return RedirectToAction("Index");
        }
    }
}