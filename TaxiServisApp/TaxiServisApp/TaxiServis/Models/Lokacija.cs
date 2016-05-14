using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
   public class Lokacija
    {
        int id { get; set; }
        string sirina { get; set; }
        string duzina { get; set; }

        public Lokacija(int id, string v1, string v2)
        {
            this.id = id;
            this.sirina = v1;
            this.duzina = v2;
        }


    }
}
