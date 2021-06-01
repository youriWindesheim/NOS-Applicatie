using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Model.Annotations;
using Model.DBLogic;

namespace Model.Model_Artikel
{
    public class Artikel : INotifyPropertyChanged
    {
        public int Artikelnummer { get; private set; }
        public string Artikelnaam { get; set; }

        public string Tekst
        {
            get
            {
                return _tekst;
            }
            set
            {
                _tekst = value;
                OnPropertyChanged();
            }
        }

        private string _tekst;
        public event EventHandler Log_Wijziging;
        public event PropertyChangedEventHandler PropertyChanged;
        public Artikel(int artikelnummer, string artikelnaam, string tekst)
        {
            this.Artikelnummer = artikelnummer;
            this.Artikelnaam = artikelnaam;
            this.Tekst = tekst;
        }

        public void Open_Artikel()
        {
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
            Log_Wijziging?.Invoke(this,new LogEventArgs(){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}]({this.Artikelnummer}) - {DateTime.Now}"});
        }

        public void Sluit_Artikel()
        {
            string methodeNaam = new StackTrace().GetFrame(0).GetMethod().Name;
            Log_Wijziging?.Invoke(this,new LogEventArgs(){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}]({this.Artikelnummer}) - {DateTime.Now}"});
            Data.Actief_Artikel = null;
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //index = 2, zodat de methodenaam correct werkt
            string methodeNaam = new StackTrace().GetFrame(2).GetMethod().Name;
            PropertyChanged?.Invoke(this, new PropChangedEventArgs(propertyName){Tekst = $"{Data.ActieveGebruiker.Personeelsnummer}:[{methodeNaam}]({this.Artikelnummer}) - {DateTime.Now}"});
        }
    }
}