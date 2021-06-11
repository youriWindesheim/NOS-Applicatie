using System;
using System.Diagnostics;
using NUnit.Framework;
using Model;
using Model.DBLogic;

namespace Model_Test
{
    public class Acties_Test
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase(24, "admin")]
        [TestCase(25, "test")]
        public void Login_Test(int personeelsnummer, string wachtwoord)
        {
            Assert.IsTrue(Acties.Login(personeelsnummer, wachtwoord));
        }

        [Test]
        public void Geheugen_Log_Bijwerken_Test()
        {
            Data.Log_Tekst = "";
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
            string tekst = $"{24}:[{methodeNaam}](12) - {DateTime.Now}";
            Acties.Geheugen_Log_Bijwerken(null, new LogEventArgs(){Tekst = tekst});
            
            //new line aangezien Acties class dat ook doet i.v.m. opmaak
            Assert.IsTrue(Data.Log_Tekst.Equals((tekst + "\n")));
        }
        
    }
}