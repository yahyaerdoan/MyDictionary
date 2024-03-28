using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyContentController : Controller
    {
        private readonly IContentService _contentService;

		public MyContentController(IContentService contentService)
		{
			_contentService = contentService;
		}

		// GET: MyContent
		public ActionResult Index()
        {
            var values = _contentService.TListByFilter(a => a.WriterId == 7);
            return View(values);
        }
    }
}