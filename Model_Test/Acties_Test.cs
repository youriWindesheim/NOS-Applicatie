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

        [Test]
        public void Login_Test()
        {
            Assert.IsTrue(Acties.Login(24, "admin"));
        }

        [Test]
        public void Geheugen_Log_Bijwerken_Test()
        {
            Data.Log_Text = "";
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
            string tekst = $"{24}:[{methodeNaam}](12) - {DateTime.Now}";
            Acties.Geheugen_Log_Bijwerken(null, new LogEventArgs(){Tekst = tekst});
            
            //new line aangezien Acties class dat ook doet i.v.m. opmaak
            Assert.IsTrue(Data.Log_Text.Equals((tekst + "\n")));
        }
        
    }
}