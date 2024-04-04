using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MyMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IWriterService _writerService;

		public MyMessageController(IMessageService messageService, IWriterService writerService)
		{
			_messageService = messageService;
			_writerService = writerService;
		}

		// GET: MyMessage
		public PartialViewResult FoldersPartial()
        {
            return PartialView();
        }
        public ActionResult InBox(string fullName)
        {
            string sessionForEMail = (string)Session["Email"];

            var matchedSessionAndEMail = _writerService.TGetByIdWithFilter(a => a.Email == sessionForEMail);
            var senderFullName = _messageService.TGetFullName(fullName).Where(x=> x.ReceverMail == matchedSessionAndEMail.Email).Select(x=> x.SenderMail);
            ViewBag.a = senderFullName;
            var pp = _writerService.TGetFullName(fullName).Where(w => w.Email == senderFullName.ToString()).Select(w => w.FirstName);
            ViewBag.c = pp;
      




            var values = _messageService.TListByFilter(a => a.ReceverMail == sessionForEMail);

            return View(values);
        }

        public ActionResult SentBox()
        {
            string sessionForEMail = (string)Session["Email"];
            var values = _messageService.TListByFilter(a => a.SenderMail == sessionForEMail);
            return View(values);
        }

        public ActionResult ReadMail(int id)
        {
            var values = _messageService.TGetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateMessage(Message message)
        {
            string sessionForEMail = (string)Session["Email"];
            message.SenderMail = sessionForEMail;
            message.Status = true;
            message.Date = DateTime.Now;
            _messageService.TAdd(message);
            return RedirectToAction("SentBox");
        }
    }
}