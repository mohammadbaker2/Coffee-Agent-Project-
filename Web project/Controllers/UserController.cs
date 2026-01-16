using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_project.Models;

namespace Web_project.Controllers
{   
    public class UserController : Controller
    {

        private CoffeeContext context { get; set; }

        public UserController(CoffeeContext ctx) => context = ctx;

        public IActionResult Index()
        {   
            var users= context.Agents.Include(a => a.City).ToList();
            return View(users); 
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agent = context.Agents.Find(id);
            ViewBag.Cities = context.Cities.OrderBy(c => c.Name).ToList();

            return View(agent); 
        }

        [HttpPost]
        public IActionResult Edit(Agent ag)
        {
            context.Agents.Update(ag);
            context.SaveChanges(); 
            return RedirectToAction("Index", "User"); 
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("agentId") == null)
            {
                return View();
            }
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Login(string name, string pass)
        {
            var g = context.Agents.FirstOrDefault(a => a.Name == name && a.Password == pass);

            if (g != null)
            {
                HttpContext.Session.SetInt32("agentId", g.AgentId);
                return RedirectToAction("Index");
            }
            else
            return View("Login");
            
        }
    }
}
