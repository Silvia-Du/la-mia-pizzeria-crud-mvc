using la_mia_pizzeria_crude_mvc.Models;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace la_mia_pizzeria_crude_mvc.Controllers
{
    public class PizzaController : Controller
    {

        readonly PizzeriaContext _ctx = new();
       
        public IActionResult Index()
        {           
            List<Pizza> pizzas = _ctx.Pizzas.Include("Category").Include("Ingredients").OrderBy(pizza => pizza.Id).ToList();
            return View("Home", pizzas);
        }


        public IActionResult Show(int id)
        {
            
            Pizza? pizza = _ctx.Pizzas.Include("Category").FirstOrDefault(x => x.Id == id);
            return pizza is null ? NotFound("Non è stata trovata nessuna corrispondenza") : View(pizza);

        }

        public IActionResult Create()
        {
            RelationsPizzas utilityClass = new();
            utilityClass.Categories = _ctx.Categories.OrderBy(x => x.Id).ToList();
            utilityClass.Ingredients = _ctx.Ingredients.OrderBy(x => x.Id).ToList();

            return View(utilityClass);
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RelationsPizzas utilityClass)
        {
            if (!ModelState.IsValid)
            {
                utilityClass.Categories = _ctx.Categories.ToList();
                utilityClass.Ingredients = _ctx.Ingredients.OrderBy(x => x.Id).ToList();

                return View(utilityClass);
            }
            utilityClass.Pizza.Ingredients = _ctx.Ingredients
                .Where(ing => utilityClass.SelectedIngredients
                .Contains(ing.Id)).ToList();

            _ctx.Pizzas.Add(utilityClass.Pizza);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Update(int id)
        {
            
            Pizza? pizza = _ctx.Pizzas.Include("Category").Include("Ingredients").FirstOrDefault(x => x.Id == id);

            if (pizza is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }

            RelationsPizzas utilityClass = new();
            utilityClass.Pizza = pizza;
            utilityClass.Categories = _ctx.Categories.ToList();
            utilityClass.Ingredients = _ctx.Ingredients.ToList();

            return View(utilityClass);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, RelationsPizzas request)
        {

            if(!ModelState.IsValid)
            {
                request.Categories = _ctx.Categories.ToList();
                request.Ingredients = _ctx.Ingredients.ToList();
                return View(request);
            }

            Pizza? pizza = _ctx.Pizzas?.Include("Ingredients").FirstOrDefault(x => x.Id == id);
            pizza.Category = _ctx.Categories?.FirstOrDefault(x => x.Id == request.Pizza.CategoryId);
            pizza.Ingredients = _ctx.Ingredients?.Where(ing => request.SelectedIngredients.Contains(ing.Id)).ToList();
            _ctx.Pizzas.Update(pizza);
            _ctx.SaveChanges();

            return View("Show", pizza);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Pizza? pizza = _ctx.Pizzas.FirstOrDefault(x => x.Id == id);

            if (pizza is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {
                _ctx.Pizzas.Remove(pizza);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

        }


    }
}