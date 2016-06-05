using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TaxiServisApp.TaxiServis.Helpers;
using TaxiServisApp.TaxiServis.Models;
using TaxiServisApp.TaxiServis.Views;
using System.ComponentModel;
using Windows.UI.Popups;
using System.ComponentModel.DataAnnotations;
namespace TaxiServisApp.TaxiServis.ViewModels
{
    public class PocetnaSupervizorViewModel : INotifyPropertyChanged
    {
        private MainPageView parameter;
        public string ImeVozacaEdit { get; set; }
        public string PrezimeVozacaEdit { get; set; }
        public string VoziloIdEdit { get; set; }
        private Vozac _selectedItem;
        public string KorisnickoImeVozacaEdit { get; set; }


        //za dispecera
        public string ImeDispeceraEdit { get; set; }
        public string PrezimeDispeceraEdit { get; set; }
        private Dispecer _selectedItemDispecer;
        public string KorisnickoImeDispeceraEdit { get; set; }
        //_____________
        public event PropertyChangedEventHandler PropertyChanged;

        private void KadaSePromijeni(string podaci)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(podaci));

        }
        int i;
        public Vozac SelectedItem//pozove se uvijek kad nekog vozaca selektuje
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (_selectedItem != null)
                {
                    ImeVozacaEdit = _selectedItem.ime.ToString();
                    PrezimeVozacaEdit = _selectedItem.prezime.ToString();
                    i = _selectedItem.id;
                    VoziloIdEdit = _selectedItem.voziloId.ToString();
                    KorisnickoImeVozacaEdit = _selectedItem.korisnickoIme;
                }
                KadaSePromijeni("SelectedItem");
                KadaSePromijeni("ImeVozacaEdit");
                KadaSePromijeni("PrezimeVozacaEdit");
                KadaSePromijeni("VoziloIdEdit");
                KadaSePromijeni("KorisnickoImeVozacaEdit");
            }
        }
        //brisanje vozaca
        public ICommand ObrisiVozacaCommand { get; set; }
        public async void obrisiVozaca(object obj)
        {//metoda za brisanje iz grida i iz baze
            using (var db = new TaxiServisDbContext())
            {
                db.Vozači.Remove(SelectedItem);
                ListaUposlenika.Remove(SelectedItem);
                var d = new MessageDialog("Uspješno ste obrisali vozača!", "Obrisan vozač");
                db.SaveChanges();
                await d.ShowAsync();
                ImeVozacaEdit = ""; PrezimeVozacaEdit = ""; VoziloIdEdit = ""; KorisnickoImeVozacaEdit = "";
                KadaSePromijeni("KorisnickoImeVozacaEdit");
                KadaSePromijeni("ImeVozacaEdit");
                KadaSePromijeni("PrezimeVozacaEdit");
                KadaSePromijeni("VoziloIdEdit");
            }

        }

        //izmjene
        public ICommand IzmjeniDispeceraCommand { get; set; }
        public async void izmjeniDispecera(object obj)
        {//metoda za brisanje iz grida i iz baze
            if (KorisnickoImeDispeceraEdit.Length <= 10)
            {
                using (var db = new TaxiServisDbContext())
                {
                    Dispecer disp = SelectedItemDispecer;
                    if (SelectedItemDispecer != null)
                    {
                        SelectedItemDispecer.ime = ImeDispeceraEdit;
                        SelectedItemDispecer.prezime = PrezimeDispeceraEdit;
                        SelectedItemDispecer.korisnickoIme = KorisnickoImeDispeceraEdit;
                        KadaSePromijeni("SelectedItemDispecer");
                        db.Dispeceri.Update(SelectedItemDispecer);
                        ListaDispecera = new ObservableCollection<Dispecer>(db.Dispeceri.ToList());
                        KadaSePromijeni("ListaDispecera");
                        db.SaveChanges();
                        var d = new MessageDialog("Uspješno ste izvršili izmjene nad dispečerom!", "Izmjene");
                    }
                }
            }
            else
            {
                var d = new MessageDialog("Korisničko ime mora biti manje od 10 karaktera", "UPOZORENJE");
                await d.ShowAsync();
            }
        }
        //izmjene
        public ICommand IzmjenivozacaCommand { get; set; }
        public async void izmjeniVozaca(object obj)
        {//metoda za brisanje iz grida i iz baze
            if (KorisnickoImeVozacaEdit.Length <= 10)
            {
                using (var db = new TaxiServisDbContext())
                {
                    if (SelectedItem != null)
                    {
                        SelectedItem.ime = ImeVozacaEdit;
                        SelectedItem.prezime = PrezimeVozacaEdit;
                        SelectedItem.korisnickoIme = KorisnickoImeVozacaEdit;
                        SelectedItem.voziloId = Int32.Parse(VoziloIdEdit);
                        KadaSePromijeni("SelectedItem");
                        db.Vozači.Update(SelectedItem);
                        ListaUposlenika = new ObservableCollection<Vozac>(db.Vozači.ToList());
                        KadaSePromijeni("ListaUposlenika");
                        db.SaveChanges();
                        var d = new MessageDialog("Uspješno ste izvršili izmjene nad vozačem!", "Izmjene");
                        await d.ShowAsync();
                    }
                }
            }
            else
            {
                var d = new MessageDialog("Korisničko ime mora biti manje od 10 karaktera", "UPOZORENJE");
                await d.ShowAsync();
            }
        }
        //brisanje dispecera
        public ICommand ObrisiDispeceraCommand { get; set; }
        public async void obrisiDispecera(object obj)
        {//metoda za brisanje iz grida i iz baze
            using (var db = new TaxiServisDbContext())
            {
                db.Dispeceri.Remove(SelectedItemDispecer);
                ListaDispecera.Remove(SelectedItemDispecer);
                var d = new MessageDialog("Uspješno ste obrisali dispečera!", "Obrisan dispečer");
                db.SaveChanges();
                await d.ShowAsync();
                KorisnickoImeVozacaEdit = ""; ImeDispeceraEdit = ""; PrezimeDispeceraEdit = "";
                KadaSePromijeni("ImeDispeceraEdit");
                KadaSePromijeni("PrezimeDispeceraEdit");
                KadaSePromijeni("KorisnickoImeDispeceraEdit");

            }

        }
        private Dispecer dispecerSelected;
        //selektovanje dispecera u gridu
        public Dispecer SelectedItemDispecer//pozove se uvijek kad nekog vozaca selektuje
        {
            get { return dispecerSelected; }
            set
            {
                dispecerSelected = value;
                if (dispecerSelected != null)
                {
                    ImeDispeceraEdit = dispecerSelected.ime;
                    PrezimeDispeceraEdit = dispecerSelected.prezime;
                    KorisnickoImeDispeceraEdit = dispecerSelected.korisnickoIme;
                }
                KadaSePromijeni("SelectedItemDispecer");
                KadaSePromijeni("ImeDispeceraEdit");
                KadaSePromijeni("PrezimeDispeceraEdit");
                KadaSePromijeni("KorisnickoImeDispeceraEdit");
            }
        }
        //konstruktor klase
        public PocetnaSupervizorViewModel(MainPageView parameter)
        {

            using (var db = new TaxiServisDbContext())
            {
                ListaUposlenika = new ObservableCollection<Vozac>(db.Vozači.ToList());

            }

            using (var db = new TaxiServisDbContext())
            {
                ListaDispecera = new ObservableCollection<Dispecer>(db.Dispeceri.ToList());
            }
            ObrisiVozacaCommand = new RelayCommand<object>(obrisiVozaca);
            //nisi ovo bila dodala u konstruktoru probaj sad al mi se prvo javi kad klanjas
            ObrisiDispeceraCommand = new RelayCommand<object>(obrisiDispecera);
            IzmjeniDispeceraCommand = new RelayCommand<object>(izmjeniDispecera);
            IzmjenivozacaCommand = new RelayCommand<object>(izmjeniVozaca);


            this.parameter = parameter;
        }
        public PocetnaSupervizorViewModel() { }

        public ObservableCollection<Vozac> ListaUposlenika { get; set; }
        public ObservableCollection<Dispecer> ListaDispecera { get; set; }
    }
}
