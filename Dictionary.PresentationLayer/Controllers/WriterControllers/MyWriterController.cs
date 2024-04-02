using Dictionary.BussinessLogicLayer.Abstract;
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
            string sessionForEMail = (string)Session["Email"];
            var values = _writerService.TListByFilter(a => a.Email == sessionForEMail);         
            return PartialView(values);
        }

        public PartialViewResult MyAboutMePartial()
        {
            string sessionForEMail = (string)Session["Email"];
            var values = _writerService.TListByFilter(a => a.Email == sessionForEMail);          
            return PartialView(values);
        }

        public PartialViewResult MyAtsPartial()
        {            
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult MyAtSettingPartial()
        {
            string sessionForEMail = (string)Session["Email"];
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == sessionForEMail);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            var values = _writerService.TGetById(matchedEmailAndWriterId);
            return PartialView(values);
        }
        [HttpPost]
        public PartialViewResult MyAtSettingPartial(Writer writer)
        {
            string sessionForEMail = (string)Session["Email"];
            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == sessionForEMail);
            var matchedEmailAndWriterId = (matchedSessionAndEMail.WriterId);
            writer.WriterId = matchedEmailAndWriterId;
            writer.Date = DateTime.Now;
            writer.Status = true;
            _writerService.TUpdate(writer);
            return PartialView("Index", "MyWriter");
        }
    }
}