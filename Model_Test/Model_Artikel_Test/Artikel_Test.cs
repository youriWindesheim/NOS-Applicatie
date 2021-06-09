using System;
using System.Diagnostics;
using Model.Model_Artikel;
using NUnit.Framework;
using Model;
using Model.DBLogic;
using Model.Model_Medewerker;

namespace Model_Test.Model_Artikel_Test
{
    public class Artikel_Test
    {

        [SetUp]
        public void Setup()
        {
            Data.ActieveGebruiker = new Medewerker(24);
        }

        [Test]
        public void Open_Artikel_Test()
        {
            Data.Log_Text = "";
            Data.Actief_Artikel = null;
            Assert.IsNull(Data.Actief_Artikel);
            
            Acties.Vraag_Artikel_Op();
            Assert.IsNotEmpty(Data.Log_Text);
            Assert.IsNotNull(Data.Actief_Artikel);
        }

        [Test]
        public void Sluit_Artikel_Test()
        {
            Acties.Vraag_Artikel_Op();
            Assert.NotNull(Data.Actief_Artikel);
            
            Data.Actief_Artikel.Sluit_Artikel();
            Assert.IsNull(Data.Actief_Artikel);
        }

        [Test]
        public void OnPropertyChanged_Test()
        {
            Acties.Vraag_Artikel_Op();
            Data.Log_Text = "";
            Assert.IsEmpty(Data.Log_Text);
            
            Data.Actief_Artikel.Tekst = "hoi";
            Assert.IsNotEmpty(Data.Log_Text);
        }
    }
}