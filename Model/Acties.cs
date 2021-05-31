namespace Model
{
    public static class Acties
    {
        public static bool Login(int personeelsnummer, string wachtwoord)
        {
            return true;
        }

        public static void Geheugen_Log_Bijwerken(string text, bool toevoegen)
        {
            if (toevoegen)
            {
                Data.Log_Text += $"\n{text}";
            }
        }

        public static void Log_Bijwerken()
        {
            
        }
        
    }
}