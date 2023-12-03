using System;
using System.Collections.Generic;

namespace Holiday.Models
{
    public partial class Scelta
    {
        public Scelta()
        {
            Richiesta = new HashSet<Richiesta>();
        }

        public int IdScelta { get; set; }
        public string TipoScelta { get; set; } = null!;

        public virtual ICollection<Richiesta> Richiesta { get; set; }
    }
}
