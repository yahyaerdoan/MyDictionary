using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class StatisticAdminController : Controller
    {
        // GET: Statistic
        //1) Toplam kategori sayısı -- Done
        //2) Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
        //3) Yazar adında 'a' harfi geçen yazar sayısı
        //4) En fazla başlığa sahip kategori adı
        //5) Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark

        private readonly ICategoryService _categoryService;

        public StatisticAdminController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ViewBag.CategoryCount = _categoryService.TGetCategoryCount();
            return View();
        }

        public PartialViewResult GooglePiechart3d()
        {
            return PartialView();
        }
    }
}