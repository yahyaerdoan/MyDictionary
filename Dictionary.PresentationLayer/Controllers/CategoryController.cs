using Dictionary.BussinessLogicLayer.Concrete;
using Dictionary.BussinessLogicLayer.FluentValidationRules;
using Dictionary.DataAccessLayer.Context;
using Dictionary.EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        CategoryValidation categoryValidation = new CategoryValidation();
        
        public ActionResult GetCategoryList()
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
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

    }
}