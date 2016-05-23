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
    }
}
