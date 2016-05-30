using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    abstract public class Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int trenutnaLokacijaId { get; set; }
        //public Lokacija trenutnaLokacijaId { get; set; }
        [ForeignKey("trenutnaLokacijaId")]
        public virtual Lokacija Lokacija { get; set; }
        /*Klijent(int id, Lokacija trenutnaLokacija)
        {
            this.id = id;
            this.trenutnaLokacija = trenutnaLokacija;
        }*/

        public Klijent(int id)
        {
            this.id = id;
        }
        public Klijent() { }
    }
}
