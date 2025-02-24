using Microsoft.VisualStudio.TestTools.UnitTesting;
using TD4P1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TD4P1.Models.EntityFramework;
using System.Xml;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using System.Reflection;

namespace TD4P1.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        public UtilisateursController controller;
        public FilmRatingsDBContext context;

        [TestInitialize]
        public void UtilisateursControllerTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=NotationDB; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            context = new FilmRatingsDBContext(builder.Options);
            controller = new UtilisateursController(context);
        }

        [TestMethod()]
        public void GetUtilisateurTest()
        {
            var users = controller.GetUtilisateur().Result.Value.Where(s => s.UtilisateurId <= 4).ToList();
            var usersVrai = context.Utilisateur.ToList().Where(s => s.UtilisateurId <= 4).ToList();
            Assert.AreEqual(usersVrai[0].UtilisateurId, users[0].UtilisateurId, "Erreur id 1");
            Assert.AreEqual(usersVrai[0].Nom, users[0].Nom, "Erreur Nom 1");
            Assert.AreEqual(usersVrai[0].Prenom, users[0].Prenom, "Erreur Prenom 1");
            Assert.AreEqual(usersVrai[0].Mobile, users[0].Mobile, "Erreur Mobile 1");
            Assert.AreEqual(usersVrai[0].Mail, users[0].Mail, "Erreur Mail 1");
            Assert.AreEqual(usersVrai[0].Pwd, users[0].Pwd, "Erreur Pwd 1");
            Assert.AreEqual(usersVrai[0].Rue, users[0].Rue, "Erreur Rue 1");
            Assert.AreEqual(usersVrai[0].CodePostal, users[0].CodePostal, "Erreur CodePostal 1");
            Assert.AreEqual(usersVrai[0].Ville, users[0].Ville, "Erreur Ville 1");
            Assert.AreEqual(usersVrai[0].Pays, users[0].Pays, "Erreur Pays 1");
            Assert.AreEqual(usersVrai[0].Latitude, users[0].Latitude, "Erreur Latitude 1");
            Assert.AreEqual(usersVrai[0].Longitude, users[0].Longitude, "Erreur Longitude 1");
            Assert.AreEqual(usersVrai[0].DateCreation, users[0].DateCreation, "Erreur DateCreation 1");
            Assert.AreEqual(usersVrai[1].UtilisateurId, users[1].UtilisateurId, "Erreur id 2");
            Assert.AreEqual(usersVrai[1].Nom, users[1].Nom, "Erreur Nom 2");
            Assert.AreEqual(usersVrai[1].Prenom, users[1].Prenom, "Erreur Prenom 2");
            Assert.AreEqual(usersVrai[1].Mobile, users[1].Mobile, "Erreur Mobile 2");
            Assert.AreEqual(usersVrai[1].Mail, users[1].Mail, "Erreur Mail 2");
            Assert.AreEqual(usersVrai[1].Pwd, users[1].Pwd, "Erreur Pwd 2");
            Assert.AreEqual(usersVrai[1].Rue, users[1].Rue, "Erreur Rue 2");
            Assert.AreEqual(usersVrai[1].CodePostal, users[1].CodePostal, "Erreur CodePostal 2");
            Assert.AreEqual(usersVrai[1].Ville, users[1].Ville, "Erreur Ville 2");
            Assert.AreEqual(usersVrai[1].Pays, users[1].Pays, "Erreur Pays 2");
            Assert.AreEqual(usersVrai[1].Latitude, users[1].Latitude, "Erreur Latitude 2");
            Assert.AreEqual(usersVrai[1].Longitude, users[1].Longitude, "Erreur Longitude 2");
            Assert.AreEqual(usersVrai[1].DateCreation, users[1].DateCreation, "Erreur DateCreation 2");
            Assert.AreEqual(usersVrai[2].UtilisateurId, users[2].UtilisateurId, "Erreur id 3");
            Assert.AreEqual(usersVrai[2].Nom, users[2].Nom, "Erreur Nom 3");
            Assert.AreEqual(usersVrai[2].Prenom, users[2].Prenom, "Erreur Prenom 3");
            Assert.AreEqual(usersVrai[2].Mobile, users[2].Mobile, "Erreur Mobile 3");
            Assert.AreEqual(usersVrai[2].Mail, users[2].Mail, "Erreur Mail 3");
            Assert.AreEqual(usersVrai[2].Pwd, users[2].Pwd, "Erreur Pwd 3");
            Assert.AreEqual(usersVrai[2].Rue, users[2].Rue, "Erreur Rue 3");
            Assert.AreEqual(usersVrai[2].CodePostal, users[2].CodePostal, "Erreur CodePostal 3");
            Assert.AreEqual(usersVrai[2].Ville, users[2].Ville, "Erreur Ville 3");
            Assert.AreEqual(usersVrai[2].Pays, users[2].Pays, "Erreur Pays 3");
            Assert.AreEqual(usersVrai[2].Latitude, users[2].Latitude, "Erreur Latitude 3");
            Assert.AreEqual(usersVrai[2].Longitude, users[2].Longitude, "Erreur Longitude 3");
            Assert.AreEqual(usersVrai[2].DateCreation, users[2].DateCreation, "Erreur DateCreation 3");
        }

        [TestMethod()]
        public void GetUtilisateurByIdTest_OK()
        {
            var user = controller.GetUtilisateurById(1).Result.Value;
            var userVrai = context.Utilisateur.ToList().Where(s => s.UtilisateurId == 1).FirstOrDefault();
            Assert.AreEqual(userVrai.UtilisateurId, user.UtilisateurId, "Erreur id 1");
            Assert.AreEqual(userVrai.Nom, user.Nom, "Erreur Nom 1");
            Assert.AreEqual(userVrai.Prenom, user.Prenom, "Erreur Prenom 1");
            Assert.AreEqual(userVrai.Mobile, user.Mobile, "Erreur Mobile 1");
            Assert.AreEqual(userVrai.Mail, user.Mail, "Erreur Mail 1");
            Assert.AreEqual(userVrai.Pwd, user.Pwd, "Erreur Pwd 1");
            Assert.AreEqual(userVrai.Rue, user.Rue, "Erreur Rue 1");
            Assert.AreEqual(userVrai.CodePostal, user.CodePostal, "Erreur CodePostal 1");
            Assert.AreEqual(userVrai.Ville, user.Ville, "Erreur Ville 1");
            Assert.AreEqual(userVrai.Pays, user.Pays, "Erreur Pays 1");
            Assert.AreEqual(userVrai.Latitude, user.Latitude, "Erreur Latitude 1");
            Assert.AreEqual(userVrai.Longitude, user.Longitude, "Erreur Longitude 1");
            Assert.AreEqual(userVrai.DateCreation, user.DateCreation, "Erreur DateCreation 1");
        }

        //[TestMethod()]
        //public void GetUtilisateurByIdTest_NONOK()
        //{
        //    var user = controller.GetUtilisateurById(2).Result.Value;
        //    var userVrai = context.Utilisateur.ToList().Where(s => s.UtilisateurId == 1).FirstOrDefault();
        //    Assert.AreEqual(userVrai.UtilisateurId, user.UtilisateurId, "Erreur id 1");
        //    Assert.AreEqual(userVrai.Nom, user.Nom, "Erreur Nom 1");
        //    Assert.AreEqual(userVrai.Prenom, user.Prenom, "Erreur Prenom 1");
        //    Assert.AreEqual(userVrai.Mobile, user.Mobile, "Erreur Mobile 1");
        //    Assert.AreEqual(userVrai.Mail, user.Mail, "Erreur Mail 1");
        //    Assert.AreEqual(userVrai.Pwd, user.Pwd, "Erreur Pwd 1");
        //    Assert.AreEqual(userVrai.Rue, user.Rue, "Erreur Rue 1");
        //    Assert.AreEqual(userVrai.CodePostal, user.CodePostal, "Erreur CodePostal 1");
        //    Assert.AreEqual(userVrai.Ville, user.Ville, "Erreur Ville 1");
        //    Assert.AreEqual(userVrai.Pays, user.Pays, "Erreur Pays 1");
        //    Assert.AreEqual(userVrai.Latitude, user.Latitude, "Erreur Latitude 1");
        //    Assert.AreEqual(userVrai.Longitude, user.Longitude, "Erreur Longitude 1");
        //    Assert.AreEqual(userVrai.DateCreation, user.DateCreation, "Erreur DateCreation 1");
        //}

        [TestMethod]
        public void GetUtilisateurByEmailTest_OK()
        {
            var user = controller.GetUtilisateurByEmail("gdominguez0@washingtonpost.com").Result.Value;
            var userVrai = context.Utilisateur.ToList().Where(s => s.Mail == "gdominguez0@washingtonpost.com").FirstOrDefault();
            Assert.AreEqual(userVrai.UtilisateurId, user.UtilisateurId, "Erreur id 1");
            Assert.AreEqual(userVrai.Nom, user.Nom, "Erreur Nom 1");
            Assert.AreEqual(userVrai.Prenom, user.Prenom, "Erreur Prenom 1");
            Assert.AreEqual(userVrai.Mobile, user.Mobile, "Erreur Mobile 1");
            Assert.AreEqual(userVrai.Mail, user.Mail, "Erreur Mail 1");
            Assert.AreEqual(userVrai.Pwd, user.Pwd, "Erreur Pwd 1");
            Assert.AreEqual(userVrai.Rue, user.Rue, "Erreur Rue 1");
            Assert.AreEqual(userVrai.CodePostal, user.CodePostal, "Erreur CodePostal 1");
            Assert.AreEqual(userVrai.Ville, user.Ville, "Erreur Ville 1");
            Assert.AreEqual(userVrai.Pays, user.Pays, "Erreur Pays 1");
            Assert.AreEqual(userVrai.Latitude, user.Latitude, "Erreur Latitude 1");
            Assert.AreEqual(userVrai.Longitude, user.Longitude, "Erreur Longitude 1");
            Assert.AreEqual(userVrai.DateCreation, user.DateCreation, "Erreur DateCreation 1");
        }

        //[TestMethod()]
        //public void GetUtilisateurByEmailTest_NONOK()
        //{
        //    var user = controller.GetUtilisateurById(2).Result.Value;
        //    var userVrai = context.Utilisateur.ToList().Where(s => s.UtilisateurId == 1).FirstOrDefault();
        //    Assert.AreEqual(userVrai.UtilisateurId, user.UtilisateurId, "Erreur id 1");
        //    Assert.AreEqual(userVrai.Nom, user.Nom, "Erreur Nom 1");
        //    Assert.AreEqual(userVrai.Prenom, user.Prenom, "Erreur Prenom 1");
        //    Assert.AreEqual(userVrai.Mobile, user.Mobile, "Erreur Mobile 1");
        //    Assert.AreEqual(userVrai.Mail, user.Mail, "Erreur Mail 1");
        //    Assert.AreEqual(userVrai.Pwd, user.Pwd, "Erreur Pwd 1");
        //    Assert.AreEqual(userVrai.Rue, user.Rue, "Erreur Rue 1");
        //    Assert.AreEqual(userVrai.CodePostal, user.CodePostal, "Erreur CodePostal 1");
        //    Assert.AreEqual(userVrai.Ville, user.Ville, "Erreur Ville 1");
        //    Assert.AreEqual(userVrai.Pays, user.Pays, "Erreur Pays 1");
        //    Assert.AreEqual(userVrai.Latitude, user.Latitude, "Erreur Latitude 1");
        //    Assert.AreEqual(userVrai.Longitude, user.Longitude, "Erreur Longitude 1");
        //    Assert.AreEqual(userVrai.DateCreation, user.DateCreation, "Erreur DateCreation 1");
        //}

        [TestMethod()]
        public void PostUtilisateurTest()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = controller.PostUtilisateur(userAtester).Result; // .Result pour appeler la méthode async de manière synchrone, afin d'attendre l’ajout
            // Assert
            Utilisateur? userRecupere = context.Utilisateur.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); 
                                                         // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
                                                         // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
                                                         // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }

        [TestMethod()]
        public void PutUtilisateurTest()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            Utilisateur userAtester = new Utilisateur()
            {
                UtilisateurId = 9,
                Nom = "Truc",
                Prenom = "bidule",
                Mobile = "0506070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            var result = controller.PutUtilisateur(9, userAtester).Result;
            Utilisateur? userRecupere = context.Utilisateur.Where(u => u.UtilisateurId==9).FirstOrDefault();
            // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }

        [TestMethod()]
        public void DeleteUtilisateurTest()
        {
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            Utilisateur user = new Utilisateur()
            {
                Nom = "DODEY",
                Prenom = "KENNY",
                Mobile = "0506070809",
                Mail = "dodeykmachin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            context.Utilisateur.Add(user);
            context.SaveChanges();
            var userAdd = context.Utilisateur.Where(u=>u.Mail == "dodeykmachin" + chiffre + "@gmail.com").FirstOrDefault();
            var result = controller.DeleteUtilisateur(userAdd.UtilisateurId).Result;
            userAdd = context.Utilisateur.Where(u => u.Mail == "dodeykmachin" + chiffre + "@gmail.com").FirstOrDefault();
            Assert.IsNull(userAdd, "L'utilisateur n'a pas été delete");
        }
    }
}