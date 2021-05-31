using Model;

namespace ViewModel

{
    public class Login_ViewModel
    {
        public bool Login(string personeelsnummer, string wachtwoord)
        {
            return Acties.Login(int.Parse(personeelsnummer), wachtwoord);
        }
    }
}