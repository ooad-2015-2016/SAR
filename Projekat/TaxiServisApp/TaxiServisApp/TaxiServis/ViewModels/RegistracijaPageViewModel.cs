using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    class RegistracijaPageViewModel
    {
        private LogInViewModel logInViewModel;
        public string ime { get; set; }
        public string prezime { get; set; }
        public string mail { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string ponovljenaSifra { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand NapraviNalog { get; set; }
        public ICommand PonistiRegistraciju { get; set; }
        public RegistracijaPageViewModel()
        {
            //registrovaniKlijent = new RegistrovaniKlijent();
            NapraviNalog = new RelayCommand<object>(napraviNalog, provjeriPravljenjeNaloga);

        }

        public void napraviNalog(object parametar)
        {
            bool ispravnaRegistracija = true;
            string greska = "";
            using (var db = new TaxiServisDbContext())
            {
                
                RegistrovaniKlijent noviKlijent = new RegistrovaniKlijent();
                if (sifra == null ||sifra == "" || sifra.Length < 4)
                {
                    ispravnaRegistracija = false;
                    greska += "- Sifra mora imati 4 karaktera. \n";
                }
                if(sifra == null || sifra == "" || ponovljenaSifra == null || ponovljenaSifra == "" || sifra != ponovljenaSifra)
                {

                    ispravnaRegistracija = false;
                    greska += "- Sifra i ponovljena sifra se ne poklapaju. \n";
                }

                if (ime==null || ime=="")
                {

                    ispravnaRegistracija = false;
                    greska += "- Unesite ime. \n";
                }
                if (prezime == null || prezime == "")
                {

                    ispravnaRegistracija = false;
                    greska += "- Unesite korisničko ime. \n";
                }
                if (korisnickoIme == null || korisnickoIme == "")
                {

                    ispravnaRegistracija = false;
                    greska += "- Unesite prezime. \n";
                }
                if (datumRodjenja>DateTime.Now)
                {

                    ispravnaRegistracija = false;
                    greska += "- Neispravan datum rodjenja. \n";
                }
                foreach(var i in db.RegistrovaniKlijenti)
                {
                    if(i.korisnickoIme==korisnickoIme)
                    {
                        ispravnaRegistracija = false;
                        greska += "- Korisnicko ime vec postoji. ";
                        break;
                    }

                }

                // notifikacijaRegistracije();
                //   registrovaniKlijent = new RegistrovaniKlijent();
                if (!ispravnaRegistracija)
                    ispisPoruka(greska, "Neispravna sifra");
                else
                {

                    noviKlijent.ime = this.ime;
                    noviKlijent.prezime = this.prezime;
                    noviKlijent.datumRodjenja = this.datumRodjenja;
                    noviKlijent.brojVoznji = 0;
                    noviKlijent.kilometriVoznje = 0;
                    noviKlijent.mail = this.mail;
                    noviKlijent.korisnickoIme = this.korisnickoIme;
                    noviKlijent.sifra = this.sifra;
                    noviKlijent.datumRegistracije = DateTime.Now;
                    noviKlijent.online = false;
                    Lokacija l = new Lokacija();
                    db.Lokacije.Add(l);
                    l = db.Lokacije.Last();
                    noviKlijent.Lokacija = l;
                    noviKlijent.trenutnaLokacijaId = l.id;

                    db.RegistrovaniKlijenti.Add(noviKlijent);
                    db.SaveChanges();

                    ispisPoruka("Uspješno ste izvrsili registraciju. ", "Uspjesna registracija");
                }
            }
        }

        public async void ispisPoruka(string greske, string naslov)
        {

            var dialog = new MessageDialog(greske, naslov);

            await dialog.ShowAsync();
        }
        public async void notifikacijaRegistracije()
        {
            {
                
            }
        }
        public bool provjeriPravljenjeNaloga(object parametar)
        {
            
            //Dodati: za kontrolu unosa naloga
            return true;
        }
        public RegistracijaPageViewModel(LogInViewModel logInViewModel)
        {
            this.logInViewModel = logInViewModel;
            //registrovaniKlijent = new RegistrovaniKlijent();
            NapraviNalog = new RelayCommand<object>(napraviNalog, provjeriPravljenjeNaloga);

        }
        public class DateTimeToDateTimeOffsetConverter : Windows.UI.Xaml.Data.IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, string language)
            {
                try
                {
                    DateTime date = (DateTime)value;
                    return new DateTimeOffset(date);
                }
                catch (Exception ex)
                {
                    return DateTimeOffset.MinValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                try
                {
                    DateTimeOffset dto = (DateTimeOffset)value;
                    return dto.DateTime;
                }
                catch (Exception ex)
                {
                    return DateTime.MinValue;
                }
            }
        }

    }
}
