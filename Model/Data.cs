using System.Collections.Generic;
using System.Linq;
using Model.Model_Artikel;
using Model.Model_Medewerker;

namespace Model
{
    public static class Data
    {
        public static Medewerker ActieveGebruiker { get; set; }
        public static Concept Actief_Artikel
        {
            get
            {
                return _actief_Artikel;
            }
            set
            {
                if (value != null){
                    if (Cache_Artikelen.Find(x => x.Artikelnummer == value.Artikelnummer)==null)
                    {
                        Acties.Voeg_Artikel_Aan_Cache_Toe(value);
                    } 
                }
                _actief_Artikel = value;
            } 
        }
        private static Concept _actief_Artikel;

        public static List<Concept> Cache_Artikelen
        {
            get
            {
                if (_cache_artikelen == null)
                {
                    _cache_artikelen = new List<Concept>();
                }
                return _cache_artikelen;
            }
        }

        private static List<Concept> _cache_artikelen;

        public static Queue<Medewerker> Cache_Medewerkers { get; set; }

        public static string Log_Tekst
        {
            get
            {
                if (_log_tekst == null)
                {
                    _log_tekst = "";
                }
                return _log_tekst;
            }
            set
            {
                _log_tekst = value;
            }
        }

        private static string _log_tekst;
        public static int Max_cache_artikelen = 3;
    }
}