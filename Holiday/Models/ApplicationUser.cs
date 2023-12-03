using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Holiday.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [StringLength(50)]
        public string Cognome { get; set; } = null!;

        public decimal Ore { get; set; } = 180;

        public virtual ICollection<Richiesta> Richiesta { get; set; } = null!;
    }

}
