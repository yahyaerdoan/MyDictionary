using Dictionary.BussinessLogicLayer.Abstract;
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
            string sessionForEMail = (string)Session["Email"];
            var values = _writerService.TListByFilter(a => a.Email == sessionForEMail);
            return PartialView(values);
        }
    }
}