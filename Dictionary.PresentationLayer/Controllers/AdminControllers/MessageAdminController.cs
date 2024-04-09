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
        //public string GetUserNameFromSession()
        //{
        //    var values =  (string)Session["UserName"];
        //    return values;
        //}

        // GET: MessageAdmin
        public ActionResult Index()
        {
            string getUserNameFromSession = (string)Session["Email"];
            var receverFullName = _messageService.TGetMessageInfoBySenderMail(x => x.ReceverMail == getUserNameFromSession);
            return View(receverFullName);
        }

        public ActionResult SentBox()
        {
            string getUserNameFromSession = (string)Session["Email"];
            var senderFullName = _messageService.TGetMessageInfoByReceverMail(x => x.SenderMail == getUserNameFromSession);
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
            string getUserNameFromSession = (string)Session["Email"];
            message.SenderMail = getUserNameFromSession;
            message.Status = true;
            message.Date = DateTime.Now;
            _messageService.TAdd(message);
            return RedirectToAction("SentBox");
        }
    }
}