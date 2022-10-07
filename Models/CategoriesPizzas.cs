using la_mia_pizzeria_crude_mvc.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class CategoriesPizzas
    {
        public Pizza Pizza { get; set; }

        public List<Category> Categories { get; set; }


        public CategoriesPizzas()
        {
            Pizza = new ();
            Categories = new();
        }
    }
}
