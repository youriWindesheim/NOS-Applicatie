using System;
using System.Windows;
using System.Windows.Controls;
using View.View_Medewerker;
using ViewModel.ViewModel_Artikel;

namespace View.View_Artikel
{
    public partial class Artikel_Inzien_View : Window
    {
        private Artikel_Inzien_ViewModel _viewmodel;
        public Artikel_Inzien_View()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            _viewmodel = new Artikel_Inzien_ViewModel();
            this.Title = _viewmodel.Get_Titel();
            this.tekst.Text = _viewmodel.Get_Inhoud();

            Setup_Expander();
        }

        private void Setup_Expander()
        {
            StackPanel SP = new StackPanel();

            Button btn;
            
            btn = new Button();
            btn.Content = "Opslaan";
            btn.Name = "btn_Opslaan";
            btn.Click += Opslaan;
            SP.Children.Add(btn);
            
            btn = new Button();
            btn.Content = "Info";
            btn.Name = "btn_Info";
            btn.Click += Info;
            SP.Children.Add(btn);

            if (_viewmodel.Is_Bevoegd())
            {
                btn = new Button();
                btn.Content = "Titel wijzigen";
                btn.Name = "btn_Titel_Wijzigen";
                btn.Click += Titel_Wijzigen;
                SP.Children.Add(btn);
                
                btn = new Button();
                btn.Content = "Verwijderen";
                btn.Name = "btn_Verwijderen";
                btn.Click += Verwijderen;
                SP.Children.Add(btn);
            }
            
            this.exp_opties.Content = SP;
        }
        private void Opslaan(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.Artikel_Opslaan(this.Title.ToString(), this.tekst.Text))
            {

            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            
        }

        private void Titel_Wijzigen(object sender, RoutedEventArgs e)
        {
            
        }
        private void Verwijderen(object sender, RoutedEventArgs e)
        {
            
        }

        private void Artikel_Inzien_View_OnClosed(object sender, EventArgs e)
        {
            _viewmodel.Artikel_Sluiten();
            View_Medewerker.Medewerker_Overzicht MO = new Medewerker_Overzicht();
            MO.Show();
        }
    }
}