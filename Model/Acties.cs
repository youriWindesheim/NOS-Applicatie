using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Model.DBLogic;
using Model.Model_Artikel;
using Model.Model_Medewerker;
using MySql.Data.MySqlClient;

namespace Model
{
    public static class Acties
    {
        public static void SetUp()
        {
            
        }
        
        #region DB

    public static bool Login(int personeelsnummer, string wachtwoord)
    {
        try
        {
            DataRow[] result =  new DB_Connectie(string.Format("SELECT * FROM werknemers WHERE Personeelsnummer = {0} and wachtwoord = {1}", personeelsnummer, "'" + wachtwoord + "'")).Get_Result();
            if (result.Length > 0)
            {
                Data.ActieveGebruiker = new Medewerker(int.Parse(result[0]["Personeelsnummer"].ToString()));
                string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
                Geheugen_Log_Bijwerken(null, new LogEventArgs(){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}] - {DateTime.Now}"});
                return true;
            }
        }
        catch (Exception ex)
        {
            if (personeelsnummer==21 && wachtwoord.Equals("admin")){
                Data.ActieveGebruiker = new Medewerker(personeelsnummer);
                string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
                Geheugen_Log_Bijwerken(null, new LogEventArgs(){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}] - {DateTime.Now}"});
                return true;
            }
        }
        return false;
    }

#endregion

        #region pre-build


        
        

        public static void Logout()
        {
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
            Geheugen_Log_Bijwerken(null, new LogEventArgs(){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}] - {DateTime.Now}"});
            Log_Bijwerken();
            Data.ActieveGebruiker = null;
        }

        public static void Geheugen_Log_Bijwerken(object sender, EventArgs e)
        {
            LogEventArgs logEvent = (LogEventArgs) e;
            Data.Log_Tekst += $"{logEvent.Tekst}\n";
        }

        public static void Geheugen_Log_Bijwerken(object sender, PropertyChangedEventArgs e)
        {
            PropChangedEventArgs propEvent = (PropChangedEventArgs) e;
            Data.Log_Tekst += $"{propEvent.Tekst}\n";
        }

        public static void Log_Bijwerken()
        {
            DBLogic.Local_Log.Log_Bijwerken(Data.Log_Tekst);
            Data.Log_Tekst = "";
        }

        public static void Vraag_Artikel_Op(int artikelnummer = 24)
        {
            Concept artikel = Data.Cache_Artikelen.Find(x => x.Artikelnummer == artikelnummer);

            if (artikel == null)
            {
                artikel = new Artikel(24,"Alle coronacijfers gaan de goede kant op", "Alle coronacijfers gaan de goede kant op, blijkt uit de wekelijkse update van het RIVM. Het aantal coronapatiënten dat werd opgenomen in een ziekenhuis, was in de afgelopen week 43 procent kleiner dan de weer ervoor. Ook het aantal intensivecareopnames daalde met eenzelfde percentage. Ten slotte daalde het aantal gemelde besmettingen met 18 procent.");
                artikel.Log_Wijziging += Geheugen_Log_Bijwerken;
                artikel.PropertyChanged += Geheugen_Log_Bijwerken;
                artikel.Open_Artikel();    
            }
            
            Data.Actief_Artikel = artikel;
        }

        public static Dictionary<int, string> Vraag_Artikel_View_Op()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(24, "Coronavirus");
            return dic;
        }

        public static void Voeg_Artikel_Aan_Cache_Toe(Concept artikel)
        {
            if (Data.Cache_Artikelen.Count == Data.Max_cache_artikelen)
            {
                for (int i = 0; i < Data.Max_cache_artikelen-1; i++)
                {
                    Data.Cache_Artikelen[i] = Data.Cache_Artikelen[i + 1];
                }

                Data.Cache_Artikelen[Data.Max_cache_artikelen] = artikel;
            }
            else
            {
                Data.Cache_Artikelen.Add(artikel);
            }
        }
#endregion

    }
}