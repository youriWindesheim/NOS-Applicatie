using System.Collections.Generic;
using Model.Model_Artikel;
using Model.Model_Medewerker;

namespace Model
{
    public static class Data
    {
        public static Medewerker ActieveGebruiker { get; private set; }
        public static Queue<Artikel> Cache_Artikelen { get;}
        public static Queue<Medewerker> Cache_Medewerkers { get;}
    }
}