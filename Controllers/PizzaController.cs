using la_mia_pizzeria_crude_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace la_mia_pizzeria_crude_mvc.Controllers
{
    public class PizzaController : Controller
    {
       
        public IActionResult Index()
        {
            using (PizzeriaContext db = new())
            {
                List<Pizza> pizzas = db.Pizzas.OrderBy(pizza => pizza.Id).ToList();
                return View("Home", pizzas);
            }
        }


        public IActionResult Show(int id)
        {
            using (PizzeriaContext db = new())
            {
                Pizza? pizza = db.Pizzas.FirstOrDefault(x => x.Id == id);

                return pizza is null ? NotFound("Non è stata trovata nessuna corrispondenza") : View(pizza);
            }

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
            using (PizzeriaContext db = new())
            {
                db.Pizzas.Add(pizza);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Update(int id)
        {
            
            using (PizzeriaContext db = new())
            {
                Pizza? pizza = db.Pizzas.FirstOrDefault(x => x.Id == id);
                
                return pizza is null? NotFound("Non è stata trovata nessuna corrispondenza"): View(pizza);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {

            using (PizzeriaContext db = new())
            {
                if(pizza is null)
                {
                    return NotFound("Non è stata trovata nessuna corrispondenza");
                }
                else
                {
                    
                    db.Pizzas.Update(pizza);
                    db.SaveChanges();
                    return View("Show", pizza);
                }

            }
        }


    }
}