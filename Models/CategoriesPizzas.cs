using la_mia_pizzeria_crude_mvc.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class CategoriesPizzas
    {
        //action [view,db] create - questo è un model del db
        public Pizza Pizza { get; set; }

        //action [view] è proprio la <select .. option...
        public List<Category> Categories { get; set; }


        public CategoriesPizzas()
        {
            Pizza = new ();
            Categories = new();
        }
    }
}
