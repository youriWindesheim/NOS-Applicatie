using Model;

namespace ViewModel

{
    public class Login_ViewModel
    {
        public bool Gebruiker_Login(string personeelsnummer, string wachtwoord)
        {
            return Acties.Login(int.Parse(personeelsnummer), wachtwoord);
        }
    }
}