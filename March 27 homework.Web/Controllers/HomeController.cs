using March_27_homework.Data;
using March_27_homework.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace March_27_homework.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People; Integrated Security=true;";

        public IActionResult Index()
        {
            PeopleManager manager = new(_connectionString);
            PeopleViewModel vm = new()
            {
                People = manager.GetPeople()
            };
            if (TempData["message"]!= null)
            {
                vm.Message = (string)TempData["message"];
            }
            
            return View(vm);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
       public IActionResult Add(List<Person> people)
        {
            PeopleManager manager = new(_connectionString);
            manager.AddManyPeople(people);
            TempData["message"] = $"{people.Count} people have been added";
            return Redirect("/");
        }
    }
}