using CandidaturesEnligne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace CandidaturesEnligne.Controllers
{
    
    public class HomeController : Controller
    {

        private CandidateuresEnligneContext db = new CandidateuresEnligneContext();
        // GET: Home Page
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLog(string Mail, string Password)
        {
            var ad = db.Admins.FirstOrDefault(x => x.Mail == Mail && x.Password == Password);
            if(ad != null)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Email Address Or Password Invalid";
            }
               return View("Login");
         
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult EspacePublic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ajouter(Candidat candidat,HttpPostedFileBase CVFile)
        {

                if (CVFile != null && CVFile.ContentLength > 0)
                {
                    // Generate a unique file name for the CV using the candidate's name and current timestamp
                    string fileName = $"{candidat.Prenom}_{candidat.Nom}_{DateTime.Now.Ticks}{Path.GetExtension(CVFile.FileName)}";

                    // Get the absolute path of the global directory to store CVs
                    string cvStoragePath = Server.MapPath("~/CVS");
                    // Create the global directory if it doesn't exist
                    if (!Directory.Exists(cvStoragePath))
                    {
                        Directory.CreateDirectory(cvStoragePath);
                    }

                    // Get the absolute path of the subdirectory with the candidate's name and surname
                    string candidateFolder = Path.Combine(cvStoragePath, $"{candidat.Prenom}_{candidat.Nom}");

                // Create the subdirectory if it doesn't exist
                if (!Directory.Exists(candidateFolder))
                    {
                        Directory.CreateDirectory(candidateFolder);
                    }
                var filePath = Path.Combine(candidateFolder, fileName);
                // Save the file to the specified location
                CVFile.SaveAs(filePath);
                // Get the cvs path of the subdirectory with the candidate's name and surname
                string A = Path.Combine("~/CVS", $"{candidat.Prenom}_{candidat.Nom}");
                var pathcondidat = Path.Combine(A, fileName);
               
                    candidat.CvPath = pathcondidat;
                    // Add the new object to the DbSet of your DbContext
                    db.Condidats.Add(candidat);
                    // Save the changes to persist the new object in the database
                    db.SaveChanges();
                    ViewBag.ConfirmationMessage = "Votre candidature a été soumise avec succès.";               
                     return View("Index");
                }
                return View("Index");
        }
        public ActionResult Admin()
        {
                List<Candidat> allcandidats = db.Condidats.ToList();
                return View(allcandidats);
        }
        [HttpPost]
        public ActionResult Delete(int? candidatureId)
        {
            var candidat = db.Condidats.Find(candidatureId);
            if(candidat != null)
            {
                db.Condidats.Remove(candidat);
                db.SaveChanges();
            }
            List<Candidat> allcandidats = db.Condidats.ToList();
            return RedirectToAction("Admin", allcandidats);
        }
        [HttpGet]
        public ActionResult Rechercher(string Nom, string Prenom, string Mail, string Telephone)
        {
            // Récupérer toutes les applications depuis la source de données
            List<Candidat> applications = db.Condidats.ToList();

            // Appliquer les critères de recherche
            if (!string.IsNullOrEmpty(Nom))
            {
                applications = applications.Where(a => a.Nom.Contains(Nom)).ToList();
            }

            if (!string.IsNullOrEmpty(Prenom))
            {
                applications = applications.Where(a => a.Prenom.Contains(Prenom)).ToList();
            }

            if (!string.IsNullOrEmpty(Mail))
            {
                applications = applications.Where(a => a.Mail.Contains(Mail)).ToList();
            }

            if (!string.IsNullOrEmpty(Telephone))
            {
                applications = applications.Where(a => a.Telephone.Contains(Telephone)).ToList();
            }

            // Passer les résultats de recherche à la vue
            return View("Admin", applications);
        }


    }
}