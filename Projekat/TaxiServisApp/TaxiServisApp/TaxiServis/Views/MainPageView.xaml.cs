﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public MainPageView()
        {
            this.InitializeComponent();
           // DataContext = new MainPageViewModel();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;

        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
       }*/


        //Metoda u kojoj se procesira ono što je došlo sa stranice koja je pozvala ovu stranicu
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            DataContext = (MainPageViewModel)e.Parameter;
            base.OnNavigatedTo(e);

            Korisnik korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = ((MainPageViewModel)e.Parameter).korisnik;//(Korisnik)e.Parameter;
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
        }

        //show-hide funkcionalnost menija
        private void PrikaziMeni_Click(object sender, RoutedEventArgs e)
        {
            MojSplitView.IsPaneOpen = !MojSplitView.IsPaneOpen;
        }
        //Metoda koja na osnovu odabranog menija, poziva podstranicu koja je definisana u meniju
        private void MeniStavkeListView_SelectionChanged(object sender, SelectionChangedEventArgs
       e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuPodstranica = (e.AddedItems[0] as MeniStavkeViewModel).Podstranica;
                if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, this);
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

    }
}
