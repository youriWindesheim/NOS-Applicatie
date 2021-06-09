﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModel.ViewModel_Medewerker;

namespace View.View_Medewerker
{
    /// <summary>
    /// Interaction logic for Medewerker_Overzicht.xaml
    /// </summary>
    public partial class Medewerker_Overzicht : Window
    {
        private Medewerker_Overzicht_ViewModel _viewmodel;
        public Medewerker_Overzicht()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            _viewmodel = new Medewerker_Overzicht_ViewModel();

            foreach (KeyValuePair<int, string> entry in _viewmodel.Get_Artikelen())
            {
                Button btn = new Button();
                btn.Content = entry.Value;
                btn.Tag = entry.Key;
                btn.Click += Artikel_Click;
                this.ArtikelPanel.Children.Add(btn);
            }
        }

        private void Artikel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button) sender;
            Console.WriteLine(btn.Tag);
        }
    }
}
