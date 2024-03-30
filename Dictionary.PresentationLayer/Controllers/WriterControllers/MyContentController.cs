using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
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
		private readonly IHeadService _headService;

		public MyContentController(IContentService contentService, IHeadService headService)
		{
			_contentService = contentService;
			_headService = headService;
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


		[HttpGet]
		public ActionResult CreateContent(int id)
		{
			var values = _headService.TGetById(id);
			return View(values);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult CreateContent(Content content)
		{
			string sessionForEMail = (string)Session["Email"];
			var matchedSessionAndEMail = _contentService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
			var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
			content.WriterId = matchedEmailAndWriterId;
			content.Date = DateTime.Now;
			_contentService.TAdd(content);
			return RedirectToAction("Index", "MyContent");
		}

		[HttpGet]
		public ActionResult UpdateContent(int id)
		{
			var values = _contentService.TGetById(id);
			return View(values);
		}
		[HttpPost, ValidateInput(false)]
		public ActionResult UpdateContent(Content content)
		{
			string sessionForEMail = (string)Session["Email"];
			var matchedSessionAndEMail = _contentService.TGetByIdWithFilter(a => a.Writer.Email == sessionForEMail);
			var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
			content.WriterId = matchedEmailAndWriterId;
			content.Date = DateTime.Now;
			_contentService.TUpdate(content);
			return RedirectToAction("Index", "MyContent");
		}
	}
}