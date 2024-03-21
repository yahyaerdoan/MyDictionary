using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class MessageAdminController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageAdminController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: MessageAdmin
        public ActionResult Index()
        {
            var values = _messageService.TListByFilter(a=> a.ReceverMail == "yahyajohn@gmail.com");
            return View(values);
        }

        public ActionResult SentBox()
        {
            var values = _messageService.TListByFilter(a => a.SenderMail == "yahyajohn@gmail.com");
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
            message.SenderMail = "yahyajohn@gmail.com";
            message.Status = true;
            message.Date = DateTime.Now;
            _messageService.TAdd(message);
            return RedirectToAction("SentBox");
        }
    }
}