using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GSB_CS_AIY;

namespace GSBTestUnitaire1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMois()
        {
            //création d'un objet gestionDate de type GestionDate
            GestionDate gestionDate = new GestionDate();

            //Appel de la fonction de dateMoisPrecedent() et de dateActuel()
            string uneDateMois = gestionDate.getMois();

            //Fonctionnement Assert.AreEqual() arg1:attends à avoir  arg2:ce que tu as  arg3:message

            //Test mois actuel
            Assert.AreEqual("03", uneDateMois, "La date n'est pas valide"); // reussite
            //Assert.AreEqual("04", uneDateMois, "La date n'est pas valide"); // erreur
            //Assert.AreEqual("02", uneDateMois, "La date n'est pas valide"); // erreur
            //Assert.AreEqual("", uneDateMois, "La date n'est pas valide"); // erreur


        }

    [TestMethod]
    public void TestMoisPrecedent()
    {
        //création d'un objet gestionDate de type GestionDate
        GestionDate gestionDate = new GestionDate();

        //Appel de la fonction de dateMoisPrecedent() et de dateActuel()
        string uneDateMoisPre = gestionDate.getMoisPrecedent();

        //Fonctionnement Assert.AreEqual() arg1:attends à avoir  arg2:ce que tu as  arg3:message

        //Test mois précedents
        Assert.AreEqual("02", uneDateMoisPre, "La date n'est pas valide");//reussite
        //Assert.AreEqual("01",uneDateMoisPre , "La date n'est pas valide");//erreur
        //Assert.AreEqual("03",uneDateMoisPre , "La date n'est pas valide");//erreur
        //Assert.AreEqual("",uneDateMoisPre , "La date n'est pas valide");//erreur


    }


    [TestMethod]
    public void TestAnnee()
    {
        //création d'un objet gestionDate de type GestionDate
        GestionDate gestionDate = new GestionDate();

        //Appel de la fonction de dateMoisPrecedent() et de dateActuel()
        string uneDateAnnee = gestionDate.getAnnee();

        //Fonctionnement Assert.AreEqual() arg1:attends à avoir  arg2:ce que tu as  arg3:message

        //Test annee actuel
        Assert.AreEqual("2020", uneDateAnnee, "La date n'est pas valide");//erreur
        //Assert.AreEqual("2021",uneDateAnnee , "La date n'est pas valide");//reussite
        //Assert.AreEqual("2022",uneDateAnnee , "La date n'est pas valide");//erreur
        //Assert.AreEqual("",uneDateAnnee , "La date n'est pas valide");//erreur
    }


    [TestMethod]
    public void TestJour()
    {
        //création d'un objet gestionDate de type GestionDate
        GestionDate gestionDate = new GestionDate();

        //Appel de la fonction de dateMoisPrecedent() et de dateActuel()
        int uneDateJour = gestionDate.getJour();

        //Fonctionnement Assert.AreEqual() arg1:attends à avoir  arg2:ce que tu as  arg3:message

        //Test jour actuel
        Assert.AreEqual(23, uneDateJour, "La date n'est pas valide");//reussite
        //Assert.AreEqual(20,uneDateJour , "La date n'est pas valide");//erreur
        //Assert.AreEqual(24,uneDateJour , "La date n'est pas valide");//erreur
        //Assert.AreEqual(244,uneDateJour , "La date n'est pas valide");//erreur
        //Assert.AreEqual(uneDateJour , "La date n'est pas valide");//erreur
    }
    }
}
