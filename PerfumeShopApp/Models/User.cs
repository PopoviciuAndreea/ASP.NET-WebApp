using System.ComponentModel.DataAnnotations;

namespace PerfumeShopApp.Models
{
    public class User
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", 
            ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula urmat de litere mici sau un spatiu (ex. Ana sau Ana Maria)")]
        [StringLength(35, MinimumLength = 3)]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$",
            ErrorMessage ="Numele trebuie sa inceapa cu majuscula urmat de litere mici sau spatiu (ex. Pop)")]
        [StringLength(35, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [StringLength(60)]
        public string? Adresa { get; set; }
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = " Ex. '0711-111-111' sau '0711 111 111'")]
        public string? Telefon { get; set; }

        [Display(Name = "Nume Complet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Order>? Orders { get; set; }
    }
}
