using System.ComponentModel.DataAnnotations;

namespace PerfumeShopApp.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }

        [Display(Name = "Plasare Comanda")]
        [DataType(DataType.Date)]
        public DateTime DataPlasareComanda { get; set; }

        [Display(Name = "Data Livrare")]
        [DataType(DataType.Date)]
        public DateTime DataLivrare { get; set; }

        [Display(Name = "Stare Comanda")]
        public string? StareComanda { get; set; }

    }
}
