using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.DisplayController
{
    public class HeaderController : Controller
    {
        private readonly IHeadService _headService;
        private readonly IContentService _contentService;

		public HeaderController(IHeadService headService, IContentService contentService = null)
		{
			_headService = headService;
			_contentService = contentService;
		}

		// GET: Header
		public ActionResult HeaderList()
        {
           var values = _headService.TGetAllList();
            return View(values);
        }

        public PartialViewResult ContentByHeader()
        {
            var values = _contentService.TGetAllList();
            return PartialView(values);
        }
    }
}