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
    public class PaniersController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: Paniers
        public ActionResult Index()
        {
            var paniers = db.Paniers.Include(p => p.Article).Include(p => p.Commande);
            return View(paniers.ToList());
        }
        //dubeut ajout
        // GET: Paniers
        public ActionResult Panier()
        {
            var paniers = db.Paniers.Include(p => p.Article).Include(p => p.Commande);
            return View(paniers.ToList());
        }
        public int Countelement()
        {
            //int res = (from e in Panier
            //           select e)
            //          .Count();

            var paniers = db.Paniers.Include(p => p.Article).Include(p => p.Commande).Count();
            return paniers;
        }
        public double? CounteSomme()
        {
            //int res = (from e in Panier
            //           select e)
            //          .Count();

            var Total = db.Paniers.AsEnumerable().Sum(x => x.prixArticle);

            var paniers = db.Paniers.GroupBy(c => new
            {
                c.panierId,
                c.cantite,
                c.prixArticle
            })
                        .Select(g => new
                        {
                            g.Key.panierId,
                            g.Key.cantite,
                            g.Key.prixArticle,
                            Available = g.Count()
                        });
            var pan = paniers.ToList();
            double? p = 0;
            foreach (var panier in pan)
            {
                p += panier.prixArticle;
            }
            var result = (from item in pan select item);
            result = result.OrderBy(c => c.prixArticle);
            var r = result.Sum(x => x.prixArticle);
            return r;



        }


        //fin ajout
        // GET: Paniers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // GET: Paniers/Create
        public ActionResult Create()
        {
            ViewBag.articleId = new SelectList(db.Articles, "articleId", "libelle");
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison");
            return View();
        }

        // POST: Paniers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "panierId,prixArticle,cantite,commandeId,articleId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Paniers.Add(panier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.articleId = new SelectList(db.Articles, "articleId", "libelle", panier.articleId);
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", panier.commandeId);
            return View(panier);
        }

        // GET: Paniers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            ViewBag.articleId = new SelectList(db.Articles, "articleId", "libelle", panier.articleId);
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", panier.commandeId);
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "panierId,prixArticle,cantite,commandeId,articleId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(panier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.articleId = new SelectList(db.Articles, "articleId", "libelle", panier.articleId);
            ViewBag.commandeId = new SelectList(db.Commandes, "commandeId", "lieuLaivraison", panier.commandeId);
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Panier panier = db.Paniers.Find(id);
            if (panier == null)
            {
                return HttpNotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Panier panier = db.Paniers.Find(id);
            db.Paniers.Remove(panier);
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
