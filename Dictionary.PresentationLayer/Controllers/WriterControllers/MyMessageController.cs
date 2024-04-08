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
        public ActionResult InBox()
        {
            string sessionForEMail = (string)Session["Email"];            
            var receverFullName = _messageService.TGetMessageInfoBySenderMail(x => x.ReceverMail == sessionForEMail);
            return View(receverFullName);
        }

        public ActionResult SentBox()
        {
            string sessionForEMail = (string)Session["Email"];
            var senderFullName = _messageService.TGetMessageInfoByReceverMail(x => x.SenderMail == sessionForEMail);
            return View(senderFullName);
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