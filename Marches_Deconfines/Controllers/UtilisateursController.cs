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
    public class UtilisateursController : Controller
    {
        private MarcheD14Entities db = new MarcheD14Entities();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Sm);
            return View(utilisateurs.ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid");
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "utilisateurId,nom,prenom,adresse,tel,email,loginUser,mdpUser,userRole,typeprivilege,descriptionUser,siren,ville,arrondissement,smsid")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", utilisateur.smsid);
            return View(utilisateur);
        }

        //Début Ajout
        // GET: Utilisateurs/Create
        public ActionResult Connexion_client()
        {
            if (Session["nom"] != null)
            {
                ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid");
                return RedirectToAction("ListArticleUtilisateur", "Articles", new { nom = Session["nom"].ToString() });
            }
            else
            {
                return View();
            }


        }



        [HttpPost]
        public ActionResult AutorisationClient(Utilisateur UserModel)
        {
            using (MarcheD14Entities db = new MarcheD14Entities())
            {
                var userDetails = db.Utilisateurs.Where(x => x.loginUser == UserModel.loginUser && x.mdpUser == UserModel.mdpUser && x.siren == null).FirstOrDefault();
                if (userDetails == null)
                {
                    UserModel.LoginErrorMessage = "Nom d'utilisateur ou mot de passe incorrecte";
                    return View("Connexion_client", UserModel);
                }
                else
                {
                    Session["utilisateurId"] = userDetails.utilisateurId;
                    Session["nom"] = userDetails.nom;
                    ViewBag.nom = Session["nom"];
                    return RedirectToAction("ListArticleUtilisateur", "Articles");
                }
            }

        }

        public ActionResult logoutClient()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }


        // GET: Utilisateurs/CreateCommercant
        public ActionResult Connexion_commercant()
        {
            if (Session["siren"] != null)
            {
                ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid");
                return RedirectToAction("ListMarche", "Categories", new { nom = Session["nom"].ToString() });
            }
            else
            {
                return View();

            }
        }


        [HttpPost]
        public ActionResult AutorisationCommercant(Utilisateur UserModel)
        {
            using (MarcheD14Entities db = new MarcheD14Entities())
            {
                var userDetails = db.Utilisateurs.Where(x => x.loginUser == UserModel.loginUser && x.mdpUser == UserModel.mdpUser && (x.siren == UserModel.siren && x.siren != null)).FirstOrDefault();
                if (userDetails == null)
                {
                    UserModel.LoginErrorMessage = "Nom d'utilisateur,Numéro de siren ou mot de passe incorrecte";
                    return View("Connexion_commercant", UserModel);
                }
                else
                {
                    Session["utilisateurId"] = userDetails.utilisateurId;
                    Session["nom"] = userDetails.nom;
                    Session["siren"] = userDetails.siren;
                    Session["userRole"] = userDetails.userRole;
                    return RedirectToAction("ListMarche", "Categories");
                }
            }

        }

        public ActionResult logoutCommercant()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }


        // GET: Utilisateurs/CreateClient
        public ActionResult Inscription_client()
        {
            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid");
            return View();
        }

        // POST: Utilisateurs/CreateClient
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription_client([Bind(Include = "utilisateurId,nom,prenom,adresse,tel,email,loginUser,mdpUser,userRole,typeprivilege,descriptionUser,siren,ville,arrondissement,smsid,categorieId")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", utilisateur.smsid);
            return View(utilisateur);
        }

        // GET: Utilisateurs/CreateCommercant
        public ActionResult Inscription_commercant()
        {
            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid");
            return View();
        }

        // POST: Utilisateurs/Commercant
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscription_commercant([Bind(Include = "utilisateurId,nom,prenom,adresse,tel,email,loginUser,mdpUser,userRole,typeprivilege,descriptionUser,siren,ville,arrondissement,smsid,categorieId")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", utilisateur.smsid);
            return View(utilisateur);
        }


        //FIN Ajout

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", utilisateur.smsid);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "utilisateurId,nom,prenom,adresse,tel,email,loginUser,mdpUser,userRole,typeprivilege,descriptionUser,siren,ville,arrondissement,smsid")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.smsid = new SelectList(db.Sms, "smsid", "smsid", utilisateur.smsid);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateur);
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
