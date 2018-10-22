using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using CRUDelicious.Persistance;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private CRUDeliciousDbContext _context;
        public HomeController(CRUDeliciousDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Dish> dishes = _context.Dishes.ToList();
            return View(dishes);
        }

        [HttpGet]
        [Route("/{dishid}")]
        public IActionResult Display(int dishid){
            Dish dish = _context.Dishes.Where(d => d.DishId == dishid).FirstOrDefault();

            return View(dish);
        }

        [HttpGet]
        [Route("/new")]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [Route("/new")]
        public IActionResult Create(Dish dish) {
            if(!ModelState.IsValid) {
                ViewBag.ErrorMessage = ModelState;
                return View(dish);
            } 

            _context.Add(dish);
            _context.SaveChanges();
            
            return Redirect("/");
        }

        [HttpGet]
        [Route("/edit/{dishid}")]
        public IActionResult Edit(int dishid) {
            Dish dish = _context.Dishes.Where(d => d.DishId == dishid).FirstOrDefault();

            return View(dish);
        }

        [HttpPost]
        [Route("/edit")]
        public IActionResult Edit(Dish dish) {
            
            if(!ModelState.IsValid) {
                ViewBag.ErrorMessage = ModelState;
                return View(dish);
            } 
            _context.Dishes.Update(dish);
            _context.SaveChanges();

            return Redirect("/"+dish.DishId);
        }

        [HttpGet]
        [Route("/delete/{dishid}")]
        public IActionResult Delete(int dishid) {
            _context.Dishes.Remove(new Dish {DishId = dishid});
            _context.SaveChanges();

            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
