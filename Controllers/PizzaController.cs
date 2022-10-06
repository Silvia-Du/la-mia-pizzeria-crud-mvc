using la_mia_pizzeria_crude_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace la_mia_pizzeria_crude_mvc.Controllers
{
    public class PizzaController : Controller
    {

        readonly PizzeriaContext _ctx = new();
       
        public IActionResult Index()
        {           
            List<Pizza> pizzas = _ctx.Pizzas.OrderBy(pizza => pizza.Id).ToList();
            return View("Home", pizzas);
        }


        public IActionResult Show(int id)
        {
            
            Pizza? pizza = _ctx.Pizzas.FirstOrDefault(x => x.Id == id);
            return pizza is null ? NotFound("Non è stata trovata nessuna corrispondenza") : View(pizza);

        }

        public IActionResult Create()
        {
            return View();
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                //uguale a dire return View("Create", pizza)
                return View(pizza);
            }
            
            _ctx.Pizzas.Add(pizza);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            
            Pizza? pizza = _ctx.Pizzas.FirstOrDefault(x => x.Id == id);
                
            return pizza is null? NotFound("Non è stata trovata nessuna corrispondenza"): View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {

            if(pizza is null)
            {
                return NotFound("Non è stata trovata nessuna corrispondenza");
            }
            else
            {                   
                _ctx.Pizzas.Update(pizza);
                _ctx.SaveChanges();
                return View("Show", pizza);
            }
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