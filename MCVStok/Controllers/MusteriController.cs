using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCVStok.Models.Entity;

namespace MCVStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILERs select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p)); 
            }
            return View(degerler.ToList());
           // var degerler = db.TBLMUSTERILERs.ToList();
            // return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteriler = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILERs.Find(id);
            return View("MusteriGetir", mus);
        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var mstri = db.TBLMUSTERILERs.Find(p1);
            mstri.MUSTERIAD = p1.MUSTERIAD;
            mstri.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}