using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace la_mia_pizzeria_crude_mvc.Models
{
    public class PizzeriaContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Ingredient>? Ingredients { get; set; }

        public PizzeriaContext()
        {
        }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
        : base(options)
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
