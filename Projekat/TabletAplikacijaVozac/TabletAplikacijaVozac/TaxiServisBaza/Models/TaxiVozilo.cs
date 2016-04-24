using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System.IO;
using Windows.Storage;
namespace TabletAplikacijaVozac.Models.TaxiServisBaza
{
    class TaxiVozilo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string boja { get; set; }
        public string proizvodjac { get; set; }
        public DateTime godiste { get; set; }
        public string opis { get; set; }
    }
}
