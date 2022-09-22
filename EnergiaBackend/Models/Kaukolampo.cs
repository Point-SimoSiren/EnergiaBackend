using System;
using System.Collections.Generic;

namespace EnergiaBackend.Models
{
    public partial class Kaukolampo
    {
        public int KaukolampoId { get; set; }
        public string Pvm { get; set; } = null!;
        public decimal Summa { get; set; }
        public decimal Kwh { get; set; }
    }
}
