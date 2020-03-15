using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TermsNew.Models;

namespace TermsNew.Controllers
{
    public class Terms2Controller : Controller
    {
        private raviEntities db = new raviEntities();

        public ActionResult BulkData()
        {
            // This is only for show by default one row for insert data to the database
            List<Terms2> ci = new List<Terms2> { new Terms2 { MOT_ID = 0, Abbreviations = "", Definition = "" } };
            return View(ci);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]C:\Users\rkumbar\Desktop\mazur\back up\Terms\19_2_19_two\Terms\Terms\Controllers\TermsController.cs
        public ActionResult BulkData(List<Terms2> ci)
        {
            if (ModelState.IsValid)
            {
                using (raviEntities dc = new raviEntities())
                {
                    foreach (var i in ci)
                    {
                        dc.Terms2.Add(i);
                    }
                    dc.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    ModelState.Clear();
                    ci = new List<Terms2> { new Terms2 { MOT_ID = 0, Abbreviations = "", Definition = "" } };
                }
            }
            return View(ci);
        }

    




    // GET: Terms2
    public ActionResult Index()
        {
            return View(db.Terms2.ToList());
        }

        // GET: Terms2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms2 terms2 = db.Terms2.Find(id);
            if (terms2 == null)
            {
                return HttpNotFound();
            }
            return View(terms2);
        }

        // GET: Terms2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terms2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MOT_ID,Headword,Definition,Full_form,Abbreviations,Synonyms")] Terms2 terms2)
        {


            if (ModelState.IsValid)
            {
                var isEmailAlreadyExists = db.Terms2.Any(x => x.MOT_ID == terms2.MOT_ID);
                if (isEmailAlreadyExists)
                {
                    ModelState.AddModelError(string.Empty, "MOD ID is already exists");
                    return View(terms2);
                }

                db.Terms2.Add(terms2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terms2);
        }

        // GET: Terms2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms2 terms2 = db.Terms2.Find(id);
            if (terms2 == null)
            {
                return HttpNotFound();
            }
            return View(terms2);
        }

        // POST: Terms2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MOT_ID,Headword,Definition,Full_form,Abbreviations,Synonyms")] Terms2 terms2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terms2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terms2);
        }

        // GET: Terms2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terms2 terms2 = db.Terms2.Find(id);
            if (terms2 == null)
            {
                return HttpNotFound();
            }
            return View(terms2);
        }

        // POST: Terms2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terms2 terms2 = db.Terms2.Find(id);
            db.Terms2.Remove(terms2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
