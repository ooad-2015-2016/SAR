using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
