using System.Collections.Generic;
using Model;

namespace ViewModel.ViewModel_Artikel
{
    public class Artikel_Inzien_ViewModel
    {
        public bool Artikel_Opslaan(string titel, string tekst)
        {
            if (!Data.Actief_Artikel.Artikelnaam.Equals(titel))
            {
                Data.Actief_Artikel.Artikelnaam = titel;
            }
            
            if (!Data.Actief_Artikel.Tekst.Equals(tekst))
            {
                Data.Actief_Artikel.Tekst = tekst;
            }

            return true;
        }

        public void Artikel_Sluiten()
        {
            Data.Actief_Artikel.Sluit_Artikel();
        }

        public bool Is_Artikel()
        {
            return Data.Actief_Artikel.GetType().IsSubclassOf(typeof(Model.Model_Artikel.Concept));
        }

        public bool Is_Bevoegd()
        {
            return true;
        }

        public string Get_Inhoud()
        {
            return Data.Actief_Artikel.Tekst;
        }

        public string Get_Titel()
        {
            return Data.Actief_Artikel.Artikelnaam;
        }

        public bool Set_Titel(string titel)
        {
            Data.Actief_Artikel.Artikelnaam = titel;
            return true;
        }
        
    }
}