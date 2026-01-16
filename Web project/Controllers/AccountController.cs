using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_project.Models;

namespace Web_project.Controllers
{
    public class AccountController : Controller
    {
        private CoffeeContext context { get; set; }

        public AccountController(CoffeeContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var agent = context.Agents
                               .FirstOrDefault(a => a.Name == username && a.Password == password);

            if (agent != null)
            {
                HttpContext.Session.SetString("UserRole", agent.Role);
                HttpContext.Session.SetString("Username", agent.Name);

                return agent.Role == "Admin"
                    ? RedirectToAction("AdminPanel")
                    : RedirectToAction("UserDashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }
        [HttpGet]
        public IActionResult AdminPanel()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(role))
                return RedirectToAction("Login");

            return View();
        }
        [HttpGet]
        public IActionResult AdminDashboard(string search)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Login");

            var agents = context.Agents.Include(a => a.City).AsQueryable();

            if (!string.IsNullOrEmpty(search))
                agents = agents.Where(a => a.Name.Contains(search));

            return View(agents.ToList());
        }
        [HttpGet]
        public IActionResult DeleteList()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("UserDashboard");

            var agents = context.Agents.Include(a => a.City).ToList();
            return View(agents);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("UserDashboard");

            var agent = context.Agents.Find(id);
            if (agent != null)
                context.Agents.Remove(agent);

            context.SaveChanges();
            return RedirectToAction("DeleteList");
        }
        [HttpGet]
        public IActionResult AddAgent()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Login");

            ViewBag.Cities = context.Cities.OrderBy(c => c.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddAgent(Agent agent)
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                context.Agents.Add(agent);
                context.SaveChanges();
                return RedirectToAction("AdminDashboard");
            }

            ViewBag.Cities = context.Cities.OrderBy(c => c.Name).ToList();
            return View(agent);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "You have successfully logged out!";
            return RedirectToAction("Login");
        }

    }
}
