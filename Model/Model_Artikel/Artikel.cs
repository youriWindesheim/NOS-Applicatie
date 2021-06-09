using System;
using System.ComponentModel;

namespace Model.Model_Artikel
{
    public class Artikel : Concept, INotifyPropertyChanged
    {
        public DateTime Laatst_Gewijzigd_Op { get; set; } //01-01-2021...
        public string Laatst_Gewijzigd_Door { get; set; } //P. de Vries
        public Artikel(int artikelnummer, string artikelnaam, string tekst) : base(artikelnummer, artikelnaam, tekst)
        {
            
        }
    }
}