using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
   public class Lokacija
    {
        //private string geoDuzina;
       // private string geoSirina;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string sirina { get; set; }
        public string duzina { get; set; }

        public Lokacija(int id, string v1, string v2)
        {
            this.id = id;
            this.sirina = v1;
            this.duzina = v2;
        }

        public Lokacija()
        {
        }

        public Lokacija(string geoDuzina, string geoSirina)
        {
            this.duzina = geoDuzina;
            this.sirina = geoSirina;
        }
    }
}
