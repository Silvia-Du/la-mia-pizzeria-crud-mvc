using la_mia_pizzeria_crude_mvc.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using la_mia_pizzeria_crude_mvc.Models;

namespace la_mia_pizzeria_static.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il campo nome non può avre piu di 70 caratteri")]
        public string? Name { get; set; }
        public List<Pizza>? Pizzas { get; set; }
    }
}
