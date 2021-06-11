using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Model.DBLogic
{
    public static class Local_Log
    {
        public static void Log_Bijwerken(string tekst)
        {
            string path = "log.txt";
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(tekst);
            }
        }

        public static Dictionary<int, string> Log_Uitlezen()
        {
            string path = "log.txt";
            string methodeNaam = new StackTrace().GetFrame(1).GetMethod().Name;
            int aantal_regels = Aantal_Regels(path);
            
            Dictionary<int, string> returnDictionary = new Dictionary<int, string>();
            
            if (File.Exists(path))
            {
                int row = aantal_regels-1;
                while (row >= 0)
                {
                    string line = File.ReadLines(path).Skip(row).Take(1).First();
                    string[] resultaat = line.Split(';');
                    row--;

                    // methodeNaam = Get_methodeNaam(methodeNaam);
                    // if (resultaat[1])
                    switch (Get_methodeNaam(methodeNaam))
                    {
                        case "Open_Artikel":
                            if (resultaat[1].Equals("Open_Artikel") && resultaat[0].Equals(Data.ActieveGebruiker.Personeelsnummer.ToString()))
                            {
                                returnDictionary[int.Parse(resultaat[2])] = "";
                            }
                            break;
// ????????
                    }
                }
            }

            return returnDictionary;
        }

        public static int Aantal_Regels(string path)
        {
            int i = 0;
            using (StreamReader r = new StreamReader(path))
            {
                while (r.ReadLine() != null)
                {
                    i++;
                }
            }
            return i;
        }

        public static string Get_methodeNaam(string methodeNaam)
        {
            string[] gesplitst = methodeNaam.Split('_');
            methodeNaam = "";
            for (int i = 1; i < gesplitst.Length; i++)
            {
                methodeNaam = methodeNaam + gesplitst[i];
            }

            return methodeNaam;
        }
    }
}