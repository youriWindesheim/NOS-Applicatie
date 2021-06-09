using System.Collections.Generic;
using Model;

namespace ViewModel.ViewModel_Artikel
{
    public class Artikel_Inzien_ViewModel
    {
        public void Artikel_Opslaan(string tekst)
        {
            Data.Actief_Artikel.Tekst = tekst;
        }

        public string Get_Inhoud()
        {
            return Data.Actief_Artikel.Tekst;
        }

        public string Get_Titel()
        {
            return Data.Actief_Artikel.Artikelnaam;
        }
        
    }
}