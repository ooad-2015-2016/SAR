using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    public class SesijaKlijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int id { get; set; }

        SesijaKlijent(int id)
        {
            this.id = id;
        }
    }
}
