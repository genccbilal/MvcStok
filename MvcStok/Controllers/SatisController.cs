using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
	public class SatisController : Controller
	{
		MvcDbStokEntities db = new MvcDbStokEntities();

		// Satışları Listeleme Sayfası
		public ActionResult Index()
		{
			ViewBag.Urunler = db.TBLURUNLER.ToList();
			ViewBag.Musteriler = db.TBLMUSTERILER.ToList();
			ViewBag.kategoriler = db.TBLKATEGORILER.ToList();
			return View();
		}


		[HttpGet]
		public ActionResult YeniSatis()
		{
			return View();
		}


		[HttpPost]
		public ActionResult YeniSatis(TBLSATISLAR p)
		{

			db.TBLSATISLAR.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult SatisListesi()
		{
			var satislar = db.TBLSATISLAR
			.Include("TBLURUNLER") // Ürünleri yükle
			.Include("TBLURUNLER.TBLKATEGORILER") // Kategoriyi Ürün üzerinden yükle
			.Include("TBLMUSTERILER") // Müşterileri yükle
			.ToList();

			return View(satislar);

		}
	}
}
