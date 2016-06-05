using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RegistracijaUposlenikaViewModel : INotifyPropertyChanged
    {
        private MainPageView parameter;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsVozac { get; set; }
        public bool IsDispecer { get; set; }

        public string Ime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Prezime { get; set; }
        public string Sifra { get; set; }
        public string Username { get; set; }
        public string BrojTaxija { get; set; }
        public RegistracijaUposlenikaViewModel(MainPageView parameter)
        {
            this.parameter = parameter;
            RegistrujUposlenikaCommand = new RelayCommand<object>(registrujUposlenika);

        }
        private void KadaSePromijeni(string podaci)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(podaci));

        }
        public async void registrujUposlenika(object obj)
        {
            if (Username.Length <= 10)
            {
                if (IsVozac == true)
                {

                    using (var db = new TaxiServisDbContext())
                    {
                        db.Vozači.Add(new Vozac()
                        {
                            ime = Ime,
                            prezime = Prezime,
                            datumRodjenja = DatumRodenja,
                            voziloId = Int32.Parse(BrojTaxija),
                            korisnickoIme = Username,
                            sifra = Sifra
                        }
                        );
                        db.SaveChanges();
                        Ime = "";
                        Prezime = "";

                        BrojTaxija = "";
                        Username = "";
                        Sifra = "";
                        KadaSePromijeni("Prezime");
                        KadaSePromijeni("BrojTaxija");
                        KadaSePromijeni("Username");
                        KadaSePromijeni("Sifra");


                    }
                }
                else
                {
                    using (var db = new TaxiServisDbContext())
                    {
                        db.Dispeceri.Add(new Dispecer()
                        {
                            ime = Ime,
                            prezime = Prezime,
                            datumRodjenja = DatumRodenja,
                            korisnickoIme = Username,
                            sifra = Sifra
                        }
                        );
                        db.SaveChanges();
                        Ime = " ";
                        Prezime = " ";
                        BrojTaxija = "";
                        Username = "";
                        Sifra = "";
                        KadaSePromijeni("Ime");
                        KadaSePromijeni("Prezime");
                        KadaSePromijeni("BrojTaxija");
                        KadaSePromijeni("Username");
                        KadaSePromijeni("Sifra");
                    }

                }
            }
            //ako ne valja korisnicko ime
            else
            {
                var d = new MessageDialog("Korisničko ime mora biti manje od 10 karaktera", "UPOZORENJE");
                await d.ShowAsync();
            }

        }

        public ICommand RegistrujUposlenikaCommand { get; set; }

    }
}
