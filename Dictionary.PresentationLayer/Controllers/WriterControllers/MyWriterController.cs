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
    public class MyWriterController : Controller
    {
        private readonly IWriterService _writerService;

		public MyWriterController(IWriterService writerService)
		{
			_writerService = writerService;
		}

		// GET: MyWriter
		public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MyProfilePartial()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var values = _writerService.TListByFilter(a => a.Email == session);         
            return PartialView(values);
        }

        public PartialViewResult MyAboutMePartial()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var values = _writerService.TListByFilter(a => a.Email == session);          
            return PartialView(values);
        }

        public PartialViewResult MyAtsPartial()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            var values = _writerService.TGetById(matchedEmailAndWriterId);
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult MyAtSettingPartial()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            var values = _writerService.TGetById(matchedEmailAndWriterId);
            return PartialView(values);
        }
        [HttpPost]
        public PartialViewResult MyAtSettingPartial(Writer writer)
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == session);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            writer.WriterId = matchedEmailAndWriterId;
            writer.Date = DateTime.Now;
            writer.Status = true;
            _writerService.TUpdate(writer);
            return PartialView("Index", "MyWriter");
        }
    }
}