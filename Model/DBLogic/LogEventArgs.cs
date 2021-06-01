using System;

namespace Model.DBLogic
{
    public class LogEventArgs : EventArgs
    {
        public string Tekst { get; set; }
        // public bool Toevoegen { get; set; }
    }
}