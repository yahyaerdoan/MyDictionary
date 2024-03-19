using Dictionary.BussinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
    public class ContentAdminController : Controller
    {
        // GET: ContentAdmin
        private readonly IContentService _contentSevice;

        public ContentAdminController(IContentService contentSevice)
        {
            _contentSevice = contentSevice;
        }

        public ActionResult Index(int id)
        {
            var values = _contentSevice.TListByFilter(a=> a.ContentId == id);
            return View(values);
        }
    }
}