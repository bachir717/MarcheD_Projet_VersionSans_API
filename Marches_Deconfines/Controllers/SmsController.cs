using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marches_Deconfines;

namespace Marches_Deconfines.Controllers
{
    public class SmsController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: Sms
        public ActionResult Index()
        {
            return View(db.Sms.ToList());
        }

        // GET: Sms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sm sm = db.Sms.Find(id);
            if (sm == null)
            {
                return HttpNotFound();
            }
            return View(sm);
        }

        // GET: Sms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sms/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "smsid,SommeVerse,cantite")] Sm sm)
        {
            if (ModelState.IsValid)
            {
                db.Sms.Add(sm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sm);
        }

        // GET: Sms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sm sm = db.Sms.Find(id);
            if (sm == null)
            {
                return HttpNotFound();
            }
            return View(sm);
        }

        // POST: Sms/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "smsid,SommeVerse,cantite")] Sm sm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sm);
        }

        // GET: Sms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sm sm = db.Sms.Find(id);
            if (sm == null)
            {
                return HttpNotFound();
            }
            return View(sm);
        }

        // POST: Sms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sm sm = db.Sms.Find(id);
            db.Sms.Remove(sm);
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
