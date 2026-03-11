using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCExampledemo.Models;

namespace MVCExampledemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampledemo1()
        {
            return "Neha Barnwal";
        }

        public string sampledemo2(int age, string name)
        {
            return "The name "+name+" and having age "+age;
        }

        public IActionResult sampledemo3()
        {
            int age = 34;
            string name = "Neha Barnwal";
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewData["Message"] = "Welcome to Asp.net core learning";
            ViewData["Year"] = DateTime.Now.Year;
            return View();
        }

        Employee obj = new Employee()
        {
            EmployeeId = 101,
            EmpName = "Neha",
            Salary = 34000
        };

        List<Employee> emplist = new List<Employee>()
        {
            new Employee{EmployeeId=101,EmpName="neha",Salary=34000,ImageUrl="/images/erp.jpg"},
            new Employee{EmployeeId=102,EmpName="nidhi",Salary=40000,ImageUrl="/images/myPhoto.jpg"},
            new Employee{EmployeeId=103,EmpName="nitu",Salary=30000,ImageUrl="/images/clgPhoto.jpg"}
        };

        public IActionResult collectionofobjectspassing()
        {
            return View(emplist);
        }
        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }

        public IActionResult display()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

