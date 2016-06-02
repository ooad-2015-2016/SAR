using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RegistracijaUposlenikaViewModel
    {
        private MainPageView parameter;
        public bool IsVozac { get; set; }
        public bool IsDispecer { get; set; }

        public string Ime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Prezime { get; set; }
        public string Sifra { get; set; }
        public string Username { get; set; }
        public int BrojTaxija { get; set; }
        public RegistracijaUposlenikaViewModel(MainPageView parameter)
        {
            this.parameter = parameter;
            RegistrujUposlenikaCommand = new RelayCommand<object>(registrujUposlenika);

        }

        public void registrujUposlenika(object obj)
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

                        korisnickoIme = Username,
                        sifra = Sifra
                    }
                    );
                    db.SaveChanges();
                }
            }

        }

        public ICommand RegistrujUposlenikaCommand { get; set; }

    }
}
