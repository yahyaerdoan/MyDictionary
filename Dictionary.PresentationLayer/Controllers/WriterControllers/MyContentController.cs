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
		private readonly IWriterService _writerService;

		public MyContentController(IContentService contentService, IWriterService writerService)
		{
			_contentService = contentService;
			_writerService = writerService;
		}

		// GET: MyContent
		public ActionResult Index(string sessionForEMail)
		{
			sessionForEMail = (string)Session["Email"];
			var matchedSessionAndEMail = _contentService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
			var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
			var values = _contentService.TListByFilter(a => a.WriterId == matchedEmailAndWriterId);
			return View(values);
		}
	}
}