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
    }
}