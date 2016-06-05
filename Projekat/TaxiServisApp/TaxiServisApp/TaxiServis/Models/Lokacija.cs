using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace TaxiServisApp.TaxiServis.Models
{
   public class Lokacija
    {
        //private string geoDuzina;
       // private string geoSirina;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double sirina { get; set; }
        public double duzina { get; set; }
        public string nazivLokacije { get; set; }

        public Lokacija(int id, double v1, double v2)
        {
            this.id = id;
            this.sirina = v1;
            this.duzina = v2;
        }

        public Lokacija()
        {
        }

        public Lokacija(double geoDuzina, double geoSirina)
        {
            this.duzina = geoDuzina;
            this.sirina = geoSirina;
        }
        public string postaviNazivLokacije()
        {
            postaviNazivLokacijeAsync();
            return nazivLokacije;
        }

          async void postaviNazivLokacijeAsync()
        {
            double lat = this.sirina;
            double lon = this.duzina;
            BasicGeoposition b = new BasicGeoposition();
            b.Latitude = lat;// zahtjevOdmah.lokacijaKorisika.duzina;
            b.Longitude = lon;
            Geopoint pointToReverseGeocode = new Geopoint(b);
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
            string ispisLokacije;
            if (result.Status == MapLocationFinderStatus.Success)
            {
                ispisLokacije = result.Locations[0].Address.Street + " " + result.Locations[0].Address.District.ToString() + " " + result.Locations[0].Address.Town.ToString() + ", " + result.Locations[0].Address.Country.ToString();
            }
            else ispisLokacije = lat.ToString() + ", " + lon.ToString();

            nazivLokacije = ispisLokacije;
        }
    }
}
