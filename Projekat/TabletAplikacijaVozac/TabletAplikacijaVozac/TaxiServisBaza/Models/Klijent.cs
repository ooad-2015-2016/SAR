using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletAplikacijaVozac
{
    abstract public class Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }
        Lokacija trenutnaLokacija { get; set; }

        /*Klijent(int id, Lokacija trenutnaLokacija)
        {
            this.id = id;
            this.trenutnaLokacija = trenutnaLokacija;
        }*/

        public Klijent(int id, Lokacija trenutnaLokacija)
        {
            this.id = id;
            this.trenutnaLokacija = trenutnaLokacija;
        }
    }
}
