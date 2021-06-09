using System.Windows;
using ViewModel.ViewModel_Artikel;

namespace View.View_Artikel
{
    public partial class Artikel_Inzien_View : Window
    {
        private Artikel_Inzien_ViewModel _viewmodel;
        public Artikel_Inzien_View()
        {
            InitializeComponent();
            _viewmodel = new Artikel_Inzien_ViewModel();
            this.tekst.Text = _viewmodel.Get_Inhoud();
        }

        private void Opslaan(object sender, RoutedEventArgs e)
        {
            
        }
    }
}