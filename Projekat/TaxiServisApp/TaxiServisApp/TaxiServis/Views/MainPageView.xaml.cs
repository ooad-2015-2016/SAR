using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaxiServisApp.TaxiServis.DataSource;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.ViewModels;
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
    public sealed partial class MainPageView : Page
    {
        public Korisnik _korisnik;
        //public MainPageViewModel parent;
        public MainPageView()
        {
            this.InitializeComponent();
            //DataContext = new MainPageViewModel();
           /* var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested; */

        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
       }*/

//Dodati: ovaj dio mora ici pod main page view model
        //Metoda u kojoj se procesira ono što je došlo sa stranice koja je pozvala ovu stranicu
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            DataContext = (MainPageViewModel)e.Parameter;
            
            base.OnNavigatedTo(e);
            //_korisnik = (MainPageViewModel)e.
            Korisnik korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = ((MainPageViewModel)e.Parameter)._korisnik;//(Korisnik)e.Parameter;
                _korisnik = korisnik;
            }
            var stavke = MeniStavkeListView.ItemsSource as List<MeniStavkeViewModel>;

            //dobavljanje svih meni stavki za koje prijavljeni korisnik ima pravo pristupa
         
            if (stavke == null && korisnik != null && korisnik.UlogaKorisnika != null)
            {
                stavke = new List<MeniStavkeViewModel>();
                var ulogeKorisnika = korisnik.UlogaKorisnika.Distinct().ToList();
                foreach(var u in ulogeKorisnika)
                {
                    u.Uloga.UlogaMeniStavke = u.Uloga.UlogaMeniStavke.Distinct().ToList();
                }
                foreach (var uloga in ulogeKorisnika)
                {
                    
                    foreach (var ulogaMeniStavka in uloga.Uloga.UlogaMeniStavke)
                    {
                        
                       stavke.Add(MeniStavkeViewModel.SaMeniStavke(ulogaMeniStavka.MeniStavka));
                        if (ulogaMeniStavka.MeniStavka.Naziv == "LogOut") break;
                    }
                    break;
                }
                var stavkeFiltriranoOdDuplikata=stavke.Distinct().ToList();

                MeniStavkeListView.ItemsSource = stavkeFiltriranoOdDuplikata;
                

            }
            {
                var menuPodstranica = (stavke[0] as MeniStavkeViewModel).Podstranica;
                //Type menuPodstranicaViewModel = (e.AddedItems[0] as MeniStavkeViewModel).PodstranicaViewModel.GetType();
                //var mpvm = new object();
                //menuPodstranica = new typeof();
                naslovna.Text = (stavke[0] as MeniStavkeViewModel).Naziv;
                if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, this);

            }
        }

        //show-hide funkcionalnost menija
        private void PrikaziMeni_Click(object sender, RoutedEventArgs e)
        {
            MojSplitView.IsPaneOpen = !MojSplitView.IsPaneOpen;
        }
        //Metoda koja na osnovu odabranog menija, poziva podstranicu koja je definisana u meniju
        private void MeniStavkeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (e.AddedItems.Count > 0)
            {
                var menuPodstranica = (e.AddedItems[0] as MeniStavkeViewModel).Podstranica;
                //Type menuPodstranicaViewModel = (e.AddedItems[0] as MeniStavkeViewModel).PodstranicaViewModel.GetType();
                //var mpvm = new object();
                //menuPodstranica = new typeof();
                naslovna.Text = (e.AddedItems[0] as MeniStavkeViewModel).Naziv;
                if((e.AddedItems[0] as MeniStavkeViewModel).Naziv == "LogOut")
                {
                    if (Frame.CanGoBack)
                    {
                        
                        Frame.GoBack();
                        //e.Handled = true;
                    }
                    else
                    {
                        var por = new MessageDialog("Nemoze nazad");
                        por.ShowAsync();
                    }
                    
                }
                else if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, this);

            }
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
