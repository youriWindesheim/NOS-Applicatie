using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using View.View_Medewerker;
using ViewModel;



namespace View
{
    /// <summary>
    /// Interaction logic for Login_View.xaml
    /// </summary>
    public partial class Login_View : Window
    {
        private Login_ViewModel _viewmodel;
        public Login_View()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            _viewmodel = new Login_ViewModel();
            
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            if (_viewmodel.Gebruiker_Login(this.txt_personeelsnummer.Text, this.txt_wachtwoord.Text))
            {
                Medewerker_Overzicht MO = new Medewerker_Overzicht();
                MO.Show();
                this.Hide();
            }
        }
    }
}
