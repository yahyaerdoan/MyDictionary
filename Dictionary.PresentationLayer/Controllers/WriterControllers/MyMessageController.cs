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
    public class MyMessageController : Controller
    {
        private readonly IMessageService _messageService;
		public MyMessageController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		// GET: MyMessage
		public PartialViewResult FoldersPartial()
        {
            return PartialView();
        }

        public ActionResult InBox()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var receverFullName = _messageService.TGetMessageInfoBySenderMail(x => x.ReceverMail == session);
            return View(receverFullName);
        }

        public ActionResult SentBox()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var senderFullName = _messageService.TGetMessageInfoByReceverMail(x => x.SenderMail == session);
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
            var session = SessionHelper.GetSessionIformation(Session);
            message.SenderMail = session;
            message.Status = true;
            message.Date = DateTime.Now;
            _messageService.TAdd(message);
            return RedirectToAction("SentBox");
        }
    }
}