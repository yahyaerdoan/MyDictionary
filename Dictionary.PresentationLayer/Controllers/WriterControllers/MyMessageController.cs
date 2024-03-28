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
            var values = _messageService.TListByFilter(a => a.ReceverMail == "smithjohnson@gmail.com");
            return View(values);
        }

        public ActionResult SentBox()
        {
            var values = _messageService.TListByFilter(a => a.SenderMail == "smithjohnson@gmail.com");
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
            message.SenderMail = "smithjohnson@gmail.com";
            message.Status = true;
            message.Date = DateTime.Now;
            _messageService.TAdd(message);
            return RedirectToAction("SentBox");
        }
    }
}