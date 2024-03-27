using Dictionary.BussinessLogicLayer.Abstract;
using Dictionary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary.PresentationLayer.Controllers.AdminControllers
{
	public class GalleryAdminController : Controller
	{
		// GET: GalleryAdmin
		private readonly IGalleryService _galleryService;

		public GalleryAdminController(IGalleryService galleryService)
		{
			_galleryService = galleryService;
		}

		public ActionResult Index()
		{
			var values = _galleryService.TGetAllList();
			return View(values);
		}

		[HttpGet]
		public ActionResult CreateGallery()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateGallery(Gallery gallery)
		{
			if (Request.Files.Count > 0)
			{
				string fileName = Path.GetFileName(Request.Files[0].FileName);
				string extension = Path.GetExtension(Request.Files[0].FileName);
				string imagePath = "~/Template/Images/" + fileName + extension;
				Request.Files[0].SaveAs(Server.MapPath(imagePath));
				gallery.Image = "/Template/Images/" + fileName + extension;
				_galleryService.TAdd(gallery);
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}		
		}


		[HttpGet]
		public ActionResult UpdateGallery(int id)
		{
			var values = _galleryService.TGetById(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateGallery(Gallery gallery)
		{
			if (Request.Files.Count > 0)
			{

				string fileName = Path.GetFileName(Request.Files[0].FileName);
				string extension = Path.GetExtension(Request.Files[0].FileName);
				string imagePath = "~/Template/Images/" + fileName + extension;
				//System.IO.File.Delete(Server.MapPath(imagePath));
				Request.Files[0].SaveAs(Server.MapPath(imagePath));
				gallery.Image = "/Template/Images/" + fileName + extension;				
				_galleryService.TUpdate(gallery);
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
	}
}