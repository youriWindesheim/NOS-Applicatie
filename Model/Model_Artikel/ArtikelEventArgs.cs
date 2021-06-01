using System;

namespace Model.Model_Artikel
{
    public class ArtikelEventArgs : EventArgs
    {
        public string Tekst { get; set; }
        public bool Toevoegen { get; set; }
    }
}