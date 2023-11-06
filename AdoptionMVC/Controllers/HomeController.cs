using AdoptionMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AdoptionMVC.Controllers
{
    public class HomeController : Controller
    {
       public AdoptionDbContext db = new AdoptionDbContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string selectedValue)
        {
            int iCNT = 1;

            string breed = "";

            List<Animal> filteredPets = db.Animals.ToList();
            List<SelectListItem> AllPets = new List<SelectListItem>();

            foreach (Animal animal in filteredPets)
            {
                AllPets.Add(new SelectListItem { Text = animal.Breed.ToString(), Value = iCNT.ToString() });
                iCNT++;
            }

            ViewBag.AllPets = AllPets;

            if (selectedValue != null) breed = AllPets.FirstOrDefault(x => x.Value == selectedValue).Text;

            if (breed != "")                
                filteredPets = db.Animals.Where(x => x.Breed == breed).ToList();

            ViewBag.FilteredPets = filteredPets;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetPets(string value)
        {
            return RedirectToAction("Index", new { selectedValue = value });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}