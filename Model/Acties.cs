using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Model.DBLogic;
using Model.Model_Artikel;

namespace Model
{
    public static class Acties
    {
        public static void SetUp()
        {
            
        }
        public static bool Login(int personeelsnummer, string wachtwoord)
        {
            return true;
        }

        public static void Geheugen_Log_Bijwerken(object sender, EventArgs e)
        {
            LogEventArgs logEvent = (LogEventArgs) e;
            Data.Log_Text += $"{logEvent.Tekst}\n";
        }

        public static void Geheugen_Log_Bijwerken(object sender, PropertyChangedEventArgs e)
        {
            PropChangedEventArgs propEvent = (PropChangedEventArgs) e;
            Data.Log_Text += $"{propEvent.Tekst}\n";
        }

        public static void Log_Bijwerken()
        {
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
        }

        public static void Vraag_Artikel_Op()
        {
            Artikel artikel = new Artikel(24,"Alle coronacijfers gaan de goede kant op", "Alle coronacijfers gaan de goede kant op, blijkt uit de wekelijkse update van het RIVM. Het aantal coronapatiënten dat werd opgenomen in een ziekenhuis, was in de afgelopen week 43 procent kleiner dan de weer ervoor. Ook het aantal intensivecareopnames daalde met eenzelfde percentage. Ten slotte daalde het aantal gemelde besmettingen met 18 procent.");
            artikel.Log_Wijziging += Geheugen_Log_Bijwerken;
            artikel.PropertyChanged += Geheugen_Log_Bijwerken;
            artikel.Open_Artikel();
            Data.Actief_Artikel = artikel;
        }

        public static Dictionary<int, string> Vraag_Artikel_View_Op()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(24, "Coronavirus");
            return dic;
        }

    }
}