using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp
{
    public class NeregistrovaniKlijent:Klijent
    {
        int id { get; set; }
        public NeregistrovaniKlijent(int id) : base(id) { }


    }
}
