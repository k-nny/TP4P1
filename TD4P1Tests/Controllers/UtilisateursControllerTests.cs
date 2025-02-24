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
using TD4P1.Models.Repository;
using TD4P1.Models.DataManager;
using NuGet.ContentModel;
using Moq;

namespace TD4P1.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        public UtilisateursController controller;
        public FilmRatingsDBContext context;
        private IDataRepository<Utilisateur> dataRepository;

        [TestInitialize]
        public void UtilisateursControllerTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=NotationDB; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            context = new FilmRatingsDBContext(builder.Options);
            dataRepository = new UtilisateurManager(context);
            controller = new UtilisateursController(dataRepository);
        }

        [TestMethod()]
        public void GetUtilisateurTest()
        {
            var users = controller.GetUtilisateur().Result.Value.Where(s => s.UtilisateurId <= 4).ToList();
            var usersVrai = context.Utilisateur.ToList().Where(s => s.UtilisateurId <= 4).ToList();
            Assert.AreEqual(usersVrai[0], users[0]);
            Assert.AreEqual(usersVrai[1], users[1]);
            Assert.AreEqual(usersVrai[2], users[2]);
            //Assert.AreEqual(usersVrai[0].UtilisateurId, users[0].UtilisateurId, "Erreur id 1");
            //Assert.AreEqual(usersVrai[0].Nom, users[0].Nom, "Erreur Nom 1");
            //Assert.AreEqual(usersVrai[0].Prenom, users[0].Prenom, "Erreur Prenom 1");
            //Assert.AreEqual(usersVrai[0].Mobile, users[0].Mobile, "Erreur Mobile 1");
            //Assert.AreEqual(usersVrai[0].Mail, users[0].Mail, "Erreur Mail 1");
            //Assert.AreEqual(usersVrai[0].Pwd, users[0].Pwd, "Erreur Pwd 1");
            //Assert.AreEqual(usersVrai[0].Rue, users[0].Rue, "Erreur Rue 1");
            //Assert.AreEqual(usersVrai[0].CodePostal, users[0].CodePostal, "Erreur CodePostal 1");
            //Assert.AreEqual(usersVrai[0].Ville, users[0].Ville, "Erreur Ville 1");
            //Assert.AreEqual(usersVrai[0].Pays, users[0].Pays, "Erreur Pays 1");
            //Assert.AreEqual(usersVrai[0].Latitude, users[0].Latitude, "Erreur Latitude 1");
            //Assert.AreEqual(usersVrai[0].Longitude, users[0].Longitude, "Erreur Longitude 1");
            //Assert.AreEqual(usersVrai[0].DateCreation, users[0].DateCreation, "Erreur DateCreation 1");
            //Assert.AreEqual(usersVrai[1].UtilisateurId, users[1].UtilisateurId, "Erreur id 2");
            //Assert.AreEqual(usersVrai[1].Nom, users[1].Nom, "Erreur Nom 2");
            //Assert.AreEqual(usersVrai[1].Prenom, users[1].Prenom, "Erreur Prenom 2");
            //Assert.AreEqual(usersVrai[1].Mobile, users[1].Mobile, "Erreur Mobile 2");
            //Assert.AreEqual(usersVrai[1].Mail, users[1].Mail, "Erreur Mail 2");
            //Assert.AreEqual(usersVrai[1].Pwd, users[1].Pwd, "Erreur Pwd 2");
            //Assert.AreEqual(usersVrai[1].Rue, users[1].Rue, "Erreur Rue 2");
            //Assert.AreEqual(usersVrai[1].CodePostal, users[1].CodePostal, "Erreur CodePostal 2");
            //Assert.AreEqual(usersVrai[1].Ville, users[1].Ville, "Erreur Ville 2");
            //Assert.AreEqual(usersVrai[1].Pays, users[1].Pays, "Erreur Pays 2");
            //Assert.AreEqual(usersVrai[1].Latitude, users[1].Latitude, "Erreur Latitude 2");
            //Assert.AreEqual(usersVrai[1].Longitude, users[1].Longitude, "Erreur Longitude 2");
            //Assert.AreEqual(usersVrai[1].DateCreation, users[1].DateCreation, "Erreur DateCreation 2");
            //Assert.AreEqual(usersVrai[2].UtilisateurId, users[2].UtilisateurId, "Erreur id 3");
            //Assert.AreEqual(usersVrai[2].Nom, users[2].Nom, "Erreur Nom 3");
            //Assert.AreEqual(usersVrai[2].Prenom, users[2].Prenom, "Erreur Prenom 3");
            //Assert.AreEqual(usersVrai[2].Mobile, users[2].Mobile, "Erreur Mobile 3");
            //Assert.AreEqual(usersVrai[2].Mail, users[2].Mail, "Erreur Mail 3");
            //Assert.AreEqual(usersVrai[2].Pwd, users[2].Pwd, "Erreur Pwd 3");
            //Assert.AreEqual(usersVrai[2].Rue, users[2].Rue, "Erreur Rue 3");
            //Assert.AreEqual(usersVrai[2].CodePostal, users[2].CodePostal, "Erreur CodePostal 3");
            //Assert.AreEqual(usersVrai[2].Ville, users[2].Ville, "Erreur Ville 3");
            //Assert.AreEqual(usersVrai[2].Pays, users[2].Pays, "Erreur Pays 3");
            //Assert.AreEqual(usersVrai[2].Latitude, users[2].Latitude, "Erreur Latitude 3");
            //Assert.AreEqual(usersVrai[2].Longitude, users[2].Longitude, "Erreur Longitude 3");
            //Assert.AreEqual(usersVrai[2].DateCreation, users[2].DateCreation, "Erreur DateCreation 3");
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
        public void GetUtilisateurById_ExistingIdPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(1).Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurById_UnknownIdPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurById(0).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetUtilisateurByEmailTest_OK()
        {
            var user = controller.GetUtilisateurByEmail("gdominguez0@washingtonpost.com").Result.Value;
            var userVrai = context.Utilisateur.ToList().Where(s => s.Mail == "gdominguez0@washingtonpost.com").FirstOrDefault();
            Assert.AreEqual(userVrai, user);
        }

        [TestMethod]
        public void GetUtilisateurByEmail_ExistingEmailPassed_ReturnsRightItem_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByStringAsync("clilleymd@last.fm").Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("clilleymd@last.fm").Result;
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsNotNull(actionResult.Value);
            Assert.AreEqual(user, actionResult.Value as Utilisateur);
        }

        [TestMethod]
        public void GetUtilisateurByEmail_UnknownEmailPassed_ReturnsNotFoundResult_AvecMoq()
        {
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.GetUtilisateurByEmail("clilleymd@fast.fm").Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        //[TestMethod()]
        //public void GetUtilisateurByEmailTest_NONOK()
        //{
        //    var user = controller.GetUtilisateurByEmail("gdominguez0@washingtonpost.com").Result.Value;
        //    var userVrai = context.Utilisateur.ToList().Where(s => s.Mail == "gdominguez0@washingtonpst.com").FirstOrDefault();
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

        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            Utilisateur user = new Utilisateur
            {
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12345678!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = userController.PostUtilisateur(user).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<Utilisateur>), "Pas un ActionResult<Utilisateur>");
            Assert.IsInstanceOfType(actionResult.Result, typeof(CreatedAtActionResult), "Pas un CreatedAtActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
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
            Utilisateur? userRecupere = context.Utilisateur.Where(u => u.UtilisateurId == 9).FirstOrDefault();
            // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            Assert.AreEqual(userAtester.UtilisateurId, userRecupere.UtilisateurId, "Erreur id");
            Assert.AreEqual(userAtester.Nom, userRecupere.Nom, "Erreur Nom");
            Assert.AreEqual(userAtester.Prenom, userRecupere.Prenom, "Erreur Prenom");
            Assert.AreEqual(userAtester.Mobile, userRecupere.Mobile, "Erreur Mobile");
            Assert.AreEqual(userAtester.Mail, userRecupere.Mail, "Erreur Mail");
            Assert.AreEqual(userAtester.Pwd, userRecupere.Pwd, "Erreur Pwd");
            Assert.AreEqual(userAtester.Rue, userRecupere.Rue, "Erreur Rue");
            Assert.AreEqual(userAtester.CodePostal, userRecupere.CodePostal, "Erreur CodePostal");
            Assert.AreEqual(userAtester.Ville, userRecupere.Ville, "Erreur Ville");
            Assert.AreEqual(userAtester.Pays, userRecupere.Pays, "Erreur Pays");
            Assert.AreEqual(userAtester.Latitude, userRecupere.Latitude, "Erreur Latitude");
            Assert.AreEqual(userAtester.Longitude, userRecupere.Longitude, "Erreur Longitude");
            Assert.AreEqual(userAtester.DateCreation, userRecupere.DateCreation, "Erreur DateCreation");
            //Assert.AreEqual(userAtester,userRecupere);
        }

        [TestMethod]
        public void PutUtilisateurTest_AvecMoq()
        {
            // Arrange
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            var userController = new UtilisateursController(mockRepository.Object);
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 9,
                Nom = "POISSON",
                Prenom = "Pascal",
                Mobile = "1",
                Mail = "poisson@gmail.com",
                Pwd = "Toto12345678!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var actionResult = userController.PutUtilisateur(9, user);
            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(IActionResult), "Pas un IActionResult");
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsInstanceOfType(result.Value, typeof(Utilisateur), "Pas un Utilisateur");
            user.UtilisateurId = ((Utilisateur)result.Value).UtilisateurId;
            Assert.AreEqual(user, (Utilisateur)result.Value, "Utilisateurs pas identiques");
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
            var userAdd = context.Utilisateur.Where(u => u.Mail == "dodeykmachin" + chiffre + "@gmail.com").FirstOrDefault();
            var result = controller.DeleteUtilisateur(userAdd.UtilisateurId).Result;
            userAdd = context.Utilisateur.Where(u => u.Mail == "dodeykmachin" + chiffre + "@gmail.com").FirstOrDefault();
            Assert.IsNull(userAdd, "L'utilisateur n'a pas été delete");
        }
        [TestMethod]
        public void DeleteUtilisateurTest_AvecMoq()
        {
            // Arrange
            Utilisateur user = new Utilisateur
            {
                UtilisateurId = 1,
                Nom = "Calida",
                Prenom = "Lilley",
                Mobile = "0653930778",
                Mail = "clilleymd@last.fm",
                Pwd = "Toto12345678!",
                Rue = "Impasse des bergeronnettes",
                CodePostal = "74200",
                Ville = "Allinges",
                Pays = "France",
                Latitude = 46.344795F,
                Longitude = 6.4885845F
            };
            var mockRepository = new Mock<IDataRepository<Utilisateur>>();
            mockRepository.Setup(x => x.GetByIdAsync(1).Result).Returns(user);
            var userController = new UtilisateursController(mockRepository.Object);
            // Act
            var actionResult = userController.DeleteUtilisateur(1).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NoContentResult), "Pas un NoContentResult"); // Test du type de retour
        }
    }
}