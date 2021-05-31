using System.IO;

namespace Model.DBLogic
{
    public static class Local_Log
    {
        public static void Log_Bijwerken(string text)
        {
            string path = "log.txt";
            if (!File.Exists(path))
            {
                
            }
            
            StreamWriter file = new StreamWriter("WriteLines2.txt", append: true);
            file.WriteLineAsync(text);
        }
    }
}