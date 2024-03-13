using Dictionary.BussinessLogicLayer.Concrete;
using Dictionary.DataAccessLayer.Concrete.GenericRepositories;
using Dictionary.DataAccessLayer.Context;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new CategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var values = categoryManager.TGetAllList();
            return View(values);
        }

        public ActionResult GetCategoryListByFilter()
        {
            var values = categoryManager.TListByFilter(a=> a.Status== true);
            return View(values);
        }
    }
}