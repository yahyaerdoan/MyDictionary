using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.BussinessLogicLayer.SessionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.WriterControllers
{
    public class MySideBarController : Controller
    {
        private readonly IWriterService _writerService;

        public MySideBarController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        // GET: MySideBar
        public PartialViewResult IndexPartial()
        {
            var session = SessionHelper.GetSessionIformation(Session);
            var values = _writerService.TListByFilter(a => a.Email == session);
            return PartialView(values);
        }
    }
}