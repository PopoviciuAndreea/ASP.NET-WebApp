using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PerfumeShopApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string? Brand { get; set; }

        public string? Nume { get; set; }

        public string? Descriere { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        public string? Imagine { get; set; }

        public string? NumeComplet
        {
            get
            {
                return Brand + " - " + Nume;
            }
        }
    }
}
