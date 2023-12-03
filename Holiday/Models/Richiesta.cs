using System;
using System.Collections.Generic;

namespace Holiday.Models
{
    public partial class Richiesta
    {
        public int IdRichiesta { get; set; }
        public int TipoRichiesta { get; set; }
        public DateTime InizioRichiesta { get; set; }
        public DateTime FineRichiesta { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Scelta TipoRichiestaNavigation { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
