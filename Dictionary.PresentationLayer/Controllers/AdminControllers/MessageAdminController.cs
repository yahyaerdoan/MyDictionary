using Dictionary.BussinessLogicLayer.Abstract;
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
        // GET: MessageAdmin
        public ActionResult Index()
        {
            var values = _messageService.TGetAllList();
            return View(values);
        }
    }
}