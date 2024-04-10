using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.SessionHelper;
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
		private readonly IWriterService _writerService;

		public MyContentController(IContentService contentService, IHeadService headService, IWriterService writerService)
		{
			_contentService = contentService;
			_headService = headService;
			_writerService = writerService;
		}

		// GET: MyContent
		public ActionResult Index()
		{
			var session = SessionHelper.GetSessionIformation(Session);
			var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email ==  session);
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
			var session = SessionHelper.GetSessionIformation(Session);           
			var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
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
			var session = SessionHelper.GetSessionIformation(Session);           
			var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
			var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
			content.WriterId = matchedEmailAndWriterId;
			content.Date = DateTime.Now;
			_contentService.TUpdate(content);
			return RedirectToAction("Index", "MyContent");
		}
	}
}