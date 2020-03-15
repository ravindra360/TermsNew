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
    public class TermsListController : Controller
    {
        private raviEntities db = new raviEntities();
        public ActionResult BulkData()
        {
            // This is only for show by default one row for insert data to the database

            IEnumerable<SelectListItem> items = db.Terms2.Select(f => new SelectListItem
            {
                Value = f.MOT_ID.ToString(),
                Text = f.MOT_ID.ToString()

            }).Distinct();
            ViewBag.MOT_ID = items;
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]C:\Users\rkumbar\Desktop\mazur\back up\Terms\19_2_19_two\Terms\Terms\Controllers\TermsController.cs
        public ActionResult BulkData(Terms2 objTerms)
        {
            if (ModelState.IsValid)
            {
                db.Terms2.Add(objTerms);
                db.SaveChanges();
                if (objTerms.ID > 0)
                {
                    ViewBag.Success = "Inserted";
                }
                ModelState.Clear();
            }
            IEnumerable<SelectListItem> items = db.Terms2.Select(f => new SelectListItem
            {
                Value = f.MOT_ID.ToString(),
                Text = f.MOT_ID.ToString()

            }).Distinct();
            ViewBag.MOT_ID = items;
            return View();
        }

    }
}