using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaxiServisApp;
using TaxiServisApp.TaxiServis.DataSource;
using TaxiServisApp.TaxiServis.ViewModels;
using TaxiServisApp.TaxiServis.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TaxiServisApp.TaxiServis.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PocetnaSupervizorView : Page
    {
        public PocetnaSupervizorView()
        {
            this.InitializeComponent();
        }

        private void nazadButton_Click(object sender, RoutedEventArgs e)
        {
            //_________________SS-komentar___________________
            // da se vrati nazad na log in pomocu this.Frame...
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //_________________SS-komentar___________________
            //ja mislim da ovako bi trebalo ici sa stranice na stranicu 
            this.Frame.Navigate(typeof(Views.RegistracijaUposlenikaView));
        }
        //_________________SS-komentar___________________
        /* - da se u gird view ili moze list view prikazu svi podaci iz baze
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RestoranDbContext())
            {
                bazaGridView.ItemsSource = db.Uposlenici.OrderBy(c => c.Prezime).ToList();
            }
        }*/

    }
}
