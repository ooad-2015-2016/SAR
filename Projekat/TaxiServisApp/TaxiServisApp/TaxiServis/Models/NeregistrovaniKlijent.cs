using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class NeregistrovaniKlijent:Klijent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public NeregistrovaniKlijent(int id) : base(id) { }

        public NeregistrovaniKlijent()
        {
        }
    }
}
