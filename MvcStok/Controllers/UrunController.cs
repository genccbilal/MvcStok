﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
	public class UrunController : Controller
	{
		// GET: Urun

		MvcDbStokEntities db = new MvcDbStokEntities();
		public ActionResult Index()
		{
			var degerler = db.TBLURUNLER.ToList();
			return View(degerler);
		}


		[HttpGet]
		public ActionResult UrunEkle()
		{
			List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KATEGORIAD,
												 Value = i.KATEGORIID.ToString()
											 }
										   ).ToList();
			ViewBag.dgr = degerler;
			return View();
		}

		[HttpPost]
		public ActionResult UrunEkle(TBLURUNLER p1)
		{

			var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			p1.TBLKATEGORILER = ktg;
			db.TBLURUNLER.Add(p1);
			db.SaveChanges();
			return RedirectToAction("index");
		}

		public ActionResult Sil(int id)
		{
			var urun = db.TBLURUNLER.Find(id);
			db.TBLURUNLER.Remove(urun);
			db.SaveChanges();
			return RedirectToAction("index");
		}

		public ActionResult UrunGetir(int id)
		{
			var urn = db.TBLURUNLER.Find(id);
			List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KATEGORIAD,
												 Value = i.KATEGORIID.ToString()
											 }
										  ).ToList();
			ViewBag.dgr = degerler;
			return View("UrunGetir", urn);
		}

		public ActionResult UrunGuncelle(TBLURUNLER p1)
		{
			var urn = db.TBLURUNLER.Find(p1.URUNID);
			urn.URUNAD = p1.URUNAD;
			urn.MARKA = p1.MARKA;
			var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
			urn.URUNKATEGORI= ktg.KATEGORIID;
			urn.FIYAT = p1.FIYAT;
			urn.STOK = p1.STOK;
			db.SaveChanges();
			return RedirectToAction("index");


		}

	}
}