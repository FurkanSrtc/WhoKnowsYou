using Bilbakalim.Models;
using Bilbakalim.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bilbakalim.Controllers
{
    public class CreateController : Controller
    {
        // GET: Create
        public ActionResult Question()
        {
            DatabaseContext db = new DatabaseContext();
            List<Sorular> sorular = db.Sorular.ToList(); //select * from sorular


            return View();
        }


        [HttpPost]
        public ActionResult Question(string s, string c1, string c2, string c3, string c4, string c5, string c6)
        {
            string[] cevaplar = new string[] { c1, c2, c3, c4, c5, c6 };
            Response.Write(s + c1 + c2 + c3 + c4 + c5 + c6);


            return View();
        }


        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();
            List<Sorular> sorular = db.Sorular.ToList();

            //LINQ
            List<SelectListItem> sorularlist =
                (from soru in db.Sorular.ToList()
                 select new SelectListItem()
                 {
                     Text = soru.Soru,
                     Value = soru.SoruId.ToString()
                 }
                 ).ToList();

            sorularlist.Reverse();

            //Üsttekinin aynısı
            //List<SelectListItem> sorularlist = new List<SelectListItem>();
            //foreach (Sorular soru in sorular)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = soru.Soru;
            //    item.Value = soru.SoruId.ToString();
            //    sorularlist.Add(item);
            //}

            TempData["sorular"] = sorularlist;
            ViewBag.sorular = sorularlist;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSoru([Bind(Prefix = "Item1")]Sorular soru)
        {

            DatabaseContext db = new DatabaseContext();
            db.Sorular.Add(soru);
            int sonuc = db.SaveChanges();
          
            if (sonuc >0 )
            {
                TempData["Result"] = "Soru Kaydedildi!";
                TempData["Status"] = "success";

            }
            else
            {
                TempData["Result"] = "Soru Kaydedilemedi..";
                TempData["Status"] = "danger";
            }
            return RedirectToAction("Yeni","Create");
        }

        [HttpPost]
        public ActionResult YeniCevap([Bind(Prefix = "Item2")]Cevaplar cevap)
        {

            DatabaseContext db = new DatabaseContext();


            Sorular soru = db.Sorular.Where(x => x.SoruId == cevap.Soru.SoruId).FirstOrDefault();

            if (soru != null)
            {
                cevap.Soru = soru;
                db.Cevaplar.Add(cevap);
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    TempData["Result"] = "Cevap Kaydedildi!";
                    TempData["Status"] = "success";
                }
                else
                {
                    TempData["Result"] = "Cevap Kaydedilemedi..";
                    TempData["Status"] = "danger";
                }

            }


            ViewBag.Kisiler = TempData["kisiler"];
            return RedirectToAction("Yeni", "Create");
        }

    }
}