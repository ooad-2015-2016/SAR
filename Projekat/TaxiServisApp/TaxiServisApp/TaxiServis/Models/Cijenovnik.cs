using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    public class Cijenovnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        double cijenaKilometra;
        double polaznaCijena;
        DateTime vrijemeAzuriranja;
        int vrijednostBoda;
        public Cijenovnik()
        {
            polaznaCijena = 2;
            cijenaKilometra = 0.5;
            vrijednostBoda = 1;
        }
        public void postaviCijenuKilometra(double cijena)
        {
            this.cijenaKilometra = cijena;
            vrijemeAzuriranja = new DateTime();
            vrijemeAzuriranja = DateTime.Now;
        }

        public double dajCijenuKilometra()
        {
            return cijenaKilometra;
        }

        public double izracunajCijenuPoKilometru(double kilometri)
        {
            int var = dajBrojBodova(kilometri);
            if (var == 10) {
                var = 0;
                return 0;
             }
            return cijenaKilometra * kilometri + polaznaCijena;
        }
        public double izracunajKilometrePoCijeni(double cijena)
        {

            return (cijena - polaznaCijena) / cijenaKilometra;
        }

        public int dajBrojBodova(double brojKilometara)
        {
            if ((int)brojKilometara > 100) return vrijednostBoda * (int)(brojKilometara % 100);
            else return 0;
        }
    }
}
