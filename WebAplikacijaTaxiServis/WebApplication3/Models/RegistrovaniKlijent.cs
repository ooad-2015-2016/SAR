using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class RegistrovaniKlijent
    {
        public int Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string mail { get; set; }
    }
}