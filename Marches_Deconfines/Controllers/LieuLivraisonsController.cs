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
    public class LieuLivraisonsController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: LieuLivraisons
        public ActionResult Index()
        {
            return View(db.LieuLivraisons.ToList());
        }

        // GET: LieuLivraisons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LieuLivraison lieuLivraison = db.LieuLivraisons.Find(id);
            if (lieuLivraison == null)
            {
                return HttpNotFound();
            }
            return View(lieuLivraison);
        }

        // GET: LieuLivraisons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LieuLivraisons/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lieuLivraisonId,Pointderegroupement,Ville,Ad,Arrondissement")] LieuLivraison lieuLivraison)
        {
            if (ModelState.IsValid)
            {
                db.LieuLivraisons.Add(lieuLivraison);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lieuLivraison);
        }

        // GET: LieuLivraisons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LieuLivraison lieuLivraison = db.LieuLivraisons.Find(id);
            if (lieuLivraison == null)
            {
                return HttpNotFound();
            }
            return View(lieuLivraison);
        }

        // POST: LieuLivraisons/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lieuLivraisonId,Pointderegroupement,Ville,Ad,Arrondissement")] LieuLivraison lieuLivraison)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lieuLivraison).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lieuLivraison);
        }

        // GET: LieuLivraisons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LieuLivraison lieuLivraison = db.LieuLivraisons.Find(id);
            if (lieuLivraison == null)
            {
                return HttpNotFound();
            }
            return View(lieuLivraison);
        }

        // POST: LieuLivraisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LieuLivraison lieuLivraison = db.LieuLivraisons.Find(id);
            db.LieuLivraisons.Remove(lieuLivraison);
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
