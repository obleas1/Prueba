using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category")]
        public string Name { get; set; }

    }
}
