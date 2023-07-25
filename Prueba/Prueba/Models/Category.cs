using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
