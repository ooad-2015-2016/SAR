using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace TaxiServisApp.TaxiServis.Views
{
    class KorisnickiInterfacePage
    {

        public KorisnickiInterfacePage()
        {
            this.InitializeComponent();
        }


        //Metoda u kojoj se procesira ono što je došlo sa stranice koja je pozvala ovu stranicu
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Korisnik korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Korisnik)e.Parameter;
            }
            //Stavke menija koje će se prikazati
            var stavke = MeniStavkeListView.ItemsSource as List<MeniStavkeViewModel>;
            //dobavljanje svih meni stavki za koje prijavljeni korisnik ima pravo pristupa
            if (stavke == null && korisnik != null && korisnik.UlogaKorisnika != null)
            {
                stavke = new List<MeniStavkeViewModel>();
                var ulogeKorisnika = korisnik.UlogaKorisnika.ToList();
                foreach (var uloga in ulogeKorisnika)
                {
                    foreach (var ulogaMeniStavka in uloga.Uloga.UlogaMeniStavke)
                    {

                        stavke.Add(MeniStavkeViewModel.SaMeniStavke(ulogaMeniStavka.MeniStavka));
                    }
                }
                //pridruzivanje odabranih stavki menija, listview-u koji prikazuje meni
                MeniStavkeListView.ItemsSource = stavke;
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
                if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, null);
            }
        }
    }

}

