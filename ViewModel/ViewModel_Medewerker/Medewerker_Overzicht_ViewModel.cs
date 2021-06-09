using System.Collections.Generic;
using Model;

namespace ViewModel.ViewModel_Medewerker
{
    public class Medewerker_Overzicht_ViewModel
    {
        public Dictionary<int, string> Get_Artikelen()
        {
            return Acties.Vraag_Artikel_View_Op();
        }

        public void Open_Artikel(string artikelnummer)
        {
            // Acties.Vraag_Artikel_Op(int.Parse(artikelnummer));
            Acties.Vraag_Artikel_Op();
        }
    }
}