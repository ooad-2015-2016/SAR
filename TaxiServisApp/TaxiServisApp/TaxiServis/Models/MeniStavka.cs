﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiServisApp.TaxiServis.Models
{
    public class MeniStavka
    {
        public int MeniStavkaId { get; set; }
        public string Naziv { get; set; }
        public string Kod { get; set; }
        public Type Podstranica { get; set; }
        public virtual ICollection<UlogaMeniStavka> UlogaMeniStavke
        {
            get;
            set;
        }
    }
}
