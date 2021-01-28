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
    public class PaymmentsController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: Paymments
        public ActionResult Index()
        {
            var paymments = db.Paymments.Include(p => p.Commande).Include(p => p.Utilisateur);
            return View(paymments.ToList());
        }

        // GET: Paymments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paymment paymment = db.Paymments.Find(id);
            if (paymment == null)
            {
                return HttpNotFound();
            }
            return View(paymment);
        }

        // GET: Paymments/Create
        public ActionResult Create()
        {
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison");
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom");
            return View();
        }

        // POST: Paymments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "paymmentId,datePaymment,numCompte,telACommercant,telUtilisateur,utilisateurId,commandeId")] Paymment paymment)
        {
            if (ModelState.IsValid)
            {
                db.Paymments.Add(paymment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", paymment.commandeId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", paymment.utilisateurId);
            return View(paymment);
        }

        // GET: Paymments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paymment paymment = db.Paymments.Find(id);
            if (paymment == null)
            {
                return HttpNotFound();
            }
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", paymment.commandeId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", paymment.utilisateurId);
            return View(paymment);
        }

        // POST: Paymments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "paymmentId,datePaymment,numCompte,telACommercant,telUtilisateur,utilisateurId,commandeId")] Paymment paymment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", paymment.commandeId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", paymment.utilisateurId);
            return View(paymment);
        }

        // GET: Paymments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paymment paymment = db.Paymments.Find(id);
            if (paymment == null)
            {
                return HttpNotFound();
            }
            return View(paymment);
        }

        // POST: Paymments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paymment paymment = db.Paymments.Find(id);
            db.Paymments.Remove(paymment);
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
