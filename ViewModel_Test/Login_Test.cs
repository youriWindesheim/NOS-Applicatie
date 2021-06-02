using Model;
using ViewModel;
using NUnit.Framework;

namespace ViewModel_Test
{
    public class Login_Test
    {
        public Login_ViewModel viewmodel { get; set; }
        [SetUp]
        public void Setup()
        {
            viewmodel = new Login_ViewModel();
        }
        
        [TestCase("24", "admin")]
        [TestCase("0101", "fout wachtwoord")]
        public void Gebruiker_Login_Test(string personeelsnummer, string wachtwoord)
        {
            Assert.IsNull(Data.ActieveGebruiker);
            if (viewmodel.Gebruiker_Login(personeelsnummer, wachtwoord))
            {
                Assert.IsNotNull(Data.ActieveGebruiker);
            }
            else
            {
                Assert.IsNull(Data.ActieveGebruiker);
            }
        }
    }
}