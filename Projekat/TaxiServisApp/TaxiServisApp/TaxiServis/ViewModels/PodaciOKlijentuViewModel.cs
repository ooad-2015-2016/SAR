using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using Windows.UI.Popups;

namespace TaxiServisApp.TaxiServis.ViewModels
{
    public class PodaciOKlijentuViewModel
    {
        public MainPageView parent;
        public Korisnik korisnik;
        public RegistrovaniKlijent klijent { get; set; }
        public List<ZahtjevZaPrevozZaListe> zahtjeviZaPrevozZaListe { get; set; }

        public PodaciOKlijentuViewModel(MainPageView parameter)
        {
            parent = parameter;
            korisnik = parent._korisnik;
            zahtjeviZaPrevozZaListe = new List<ZahtjevZaPrevozZaListe>();
            using (var db = new TaxiServisDbContext())
            {
                //trazimo klijenta
                try {
                    foreach (var rk in db.RegistrovaniKlijenti)
                    {
                        if (rk.korisnickoIme == korisnik.KorisnickoIme)
                        {
                            klijent = rk;
                            break;
                        }
                    }
                        //trazimo njegove narudzbe odmah
                    try {
                        foreach (var z in db.NarudzbeOdmah.ToList())
                        {
                            if (z.klijentId == klijent.id)
                            {
                                ZahtjevZaPrevozZaListe zahtjevZaListu = new ZahtjevZaPrevozZaListe();
                                zahtjevZaListu.tipZahtjevaString = "Narudžba odmah";
                                zahtjevZaListu.lokacija =(from l in db.Lokacije where l.id == z.lokacijaKorisikaId select l.nazivLokacije).First();
                                zahtjevZaListu.statusNarudzbe = z.statusNarudzbe;
                                zahtjevZaListu.vrijemeNarudzbe = z.vrijemeNarudzbe;
                                zahtjeviZaPrevozZaListe.Add(zahtjevZaListu);
                            }

                        }
                        
                        }
                    catch(System.Exception)
                   {

                    }
                    //trazimo njegove rezervacije
                    try
                    {
                        foreach (var r in db.Rezervacije)
                        {
                            if (r.klijentId == klijent.id)

                                zahtjeviZaPrevozZaListe.Add(new ZahtjevZaPrevozZaListe()
                            {
                                tipZahtjevaString = "Rezervacija",
                                lokacija = (from l in db.Lokacije where l.id == r.polaznaLokacijaId select l.nazivLokacije).First() + (from l in db.Lokacije where l.id == r.krajnjaLokacijaId select l.nazivLokacije).First(),
                                    statusNarudzbe = r.statusNarudzbe,
                                vrijemeNarudzbe = r.vrijemeNarudzbe,
                                krajnjaLokacija = (from l in db.Lokacije where l.id == r.krajnjaLokacijaId select l.nazivLokacije).First()
                            });
                        }
                    }
                    catch (System.Exception)
                    {
                        
                    }
                }
                catch (Exception)
                {

                }

            }

            }
        }
    }










               
