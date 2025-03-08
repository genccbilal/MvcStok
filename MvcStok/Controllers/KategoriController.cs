using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db = new MvcDbStokEntities();


        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
		{
            return View();
		}


        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
		{
			if (!ModelState.IsValid)
			{
                return View("YeniKategori");
			}
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Sil(int id)
        {
            var katrgori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(katrgori);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult KategoriGetir(int id)
		{
            var ktg = db.TBLKATEGORILER.Find(id)    ;
            return View("KategoriGetir", ktg);
		}

        public ActionResult Guncelle(TBLKATEGORILER p1)
		{
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("index");


		}
    }
}