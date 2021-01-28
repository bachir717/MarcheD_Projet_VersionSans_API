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
    public class ArticlesController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Categorie).Include(a => a.Utilisateur);
            return View(articles.ToList());
        }
        //debut ajout
        public ActionResult ListArticle()
        {
                int i = int.Parse(Session["categorieId"].ToString());
                var articles = db.Articles.Include(a => a.Categorie).Include(a => a.Utilisateur).Where(a => a.categorieId == i);
                return View(articles.ToList());

        }

        public ActionResult ListArticleUtilisateur()
        {
            var articles = db.Articles.Include(a => a.Categorie).Include(a => a.Utilisateur).Where(a => a.categorieId == 1);
            return View(articles.ToList());

        }

        // GET: Articles/Details/5
        public ActionResult AjoutPanier(int? id)
        {
          
            List<Panier> cart = new List<Panier>();
            var art = db.Articles.Find(id);
            Panier p = new Panier
            {
                cantite = art.cantite,
                prixArticle = art.Prix,
                articleId = art.articleId
            };
            db.Paniers.Add(p);
            db.SaveChanges();
            Session["cart"] = cart;
            //return View(article);
            return RedirectToAction("Panier", "Paniers");
        }


        //fin ajout 

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "Nom");
            ViewBag.utilisateurid = new SelectList(db.Utilisateurs, "utilisateurId", "nom");
            return View();
        }

        // POST: Articles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "articleId,libelle,Prix,cantite,articleDescreption,etat,photo,categorieId,utilisateurid")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "libelle", article.categorieId);
            ViewBag.utilisateurid = new SelectList(db.Utilisateurs, "utilisateurId", "nom", article.utilisateurid);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "libelle", article.categorieId);
            ViewBag.utilisateurid = new SelectList(db.Utilisateurs, "utilisateurId", "nom", article.utilisateurid);
            return View(article);
        }

        // POST: Articles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "articleId,libelle,Prix,cantite,articleDescreption,etat,photo,categorieId,utilisateurid")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categorieId = new SelectList(db.Categories, "categorieId", "libelle", article.categorieId);
            ViewBag.utilisateurid = new SelectList(db.Utilisateurs, "utilisateurId", "nom", article.utilisateurid);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
