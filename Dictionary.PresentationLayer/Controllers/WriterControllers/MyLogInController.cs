using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyLogInController : Controller
    {
        private readonly IWriterService _writerService;

		public MyLogInController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		// GET: MyLogIn
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            var values = _writerService.TGetByIdWithFilter(a => a.Email == writer.Email && a.Password == writer.Password);
			if (values != null)
			{
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["Email"] = values.Email;
                return RedirectToAction("Index", "MyContent");
			}
			else
			{
                return View("hata");
            }           
        }
    }
}