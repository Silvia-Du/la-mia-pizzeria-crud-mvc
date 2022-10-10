using la_mia_pizzeria_crude_mvc.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class RelationsPizzas
    {
        public Pizza Pizza { get; set; }
        public List<Category> Categories { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<int> SelectedIngredients { get; set; }   

        public RelationsPizzas()
        {
            Pizza = new();
            Categories = new();
            Ingredients = new();
            SelectedIngredients = new();
        }
    }
}
