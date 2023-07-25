using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }

    }
}
