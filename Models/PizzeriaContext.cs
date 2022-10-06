using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace la_mia_pizzeria_crude_mvc.Models
{
    public class PizzeriaContext: DbContext
    {
        public DbSet<Pizza>? Pizzas { get; set; }


        public PizzeriaContext() : base()
        {
        }

        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=localhost;" +
                "Initial Catalog=db_pizzeria;" +
                "Integrated Security=True";
            optionsBuilder.UseSqlServer(connection);
        }
      
    }
}
