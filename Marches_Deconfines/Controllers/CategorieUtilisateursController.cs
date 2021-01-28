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
    public class CategorieUtilisateursController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: CategorieUtilisateurs
        public ActionResult Index()
        {
            var categorieUtilisateurs = db.CategorieUtilisateurs.Include(c => c.Categorie).Include(c => c.Utilisateur);
            return View(categorieUtilisateurs.ToList());
        }

        // GET: CategorieUtilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieUtilisateur categorieUtilisateur = db.CategorieUtilisateurs.Find(id);
            if (categorieUtilisateur == null)
            {
                return HttpNotFound();
            }
            return View(categorieUtilisateur);
        }

        // GET: CategorieUtilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "NOM");
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom");
            return View();
        }

        // POST: CategorieUtilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorieUtilisateurId,utilisateurId,categorieId")] CategorieUtilisateur categorieUtilisateur)
        {
            if (ModelState.IsValid)
            {
                db.CategorieUtilisateurs.Add(categorieUtilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categorieUtilisateur.categorieId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", categorieUtilisateur.utilisateurId);
            return View(categorieUtilisateur);
        }

        // GET: CategorieUtilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieUtilisateur categorieUtilisateur = db.CategorieUtilisateurs.Find(id);
            if (categorieUtilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categorieUtilisateur.categorieId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", categorieUtilisateur.utilisateurId);
            return View(categorieUtilisateur);
        }

        // POST: CategorieUtilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorieUtilisateurId,utilisateurId,categorieId")] CategorieUtilisateur categorieUtilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorieUtilisateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom", categorieUtilisateur.categorieId);
            ViewBag.utilisateurId = new SelectList(db.Utilisateurs, "utilisateurId", "nom", categorieUtilisateur.utilisateurId);
            return View(categorieUtilisateur);
        }

        // GET: CategorieUtilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategorieUtilisateur categorieUtilisateur = db.CategorieUtilisateurs.Find(id);
            if (categorieUtilisateur == null)
            {
                return HttpNotFound();
            }
            return View(categorieUtilisateur);
        }

        // POST: CategorieUtilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategorieUtilisateur categorieUtilisateur = db.CategorieUtilisateurs.Find(id);
            db.CategorieUtilisateurs.Remove(categorieUtilisateur);
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
