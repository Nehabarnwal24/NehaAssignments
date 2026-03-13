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
            new Employee{EmployeeId=101,EmpName="neha",Salary=34000,ImageUrl="/images/erp.jpg", DeptId=10},
            new Employee{EmployeeId=102,EmpName="nidhi",Salary=40000,ImageUrl="/images/myPhoto.jpg", DeptId=10},
            new Employee{EmployeeId=103,EmpName="nitu",Salary=30000,ImageUrl="/images/clgPhoto.jpg",DeptId=30}
        };
        public IActionResult collectionofdepts()
        {
            return View(deptlist);
        }
        public IActionResult EmpsInDept(int deptId)
        {
            var emps = emplist
                .Where(e => e.DeptId == deptId)
                .ToList();

            return View(emps);
        }
        List<Department> deptlist = new List<Department>()
        {
            new Department{DeptId=10,DeptName="Sales"},
            new Department{DeptId=20,DeptName="HR"},
            new Department{DeptId=30,DeptName="Software"}
        };

        public IActionResult mixedobjectpassing(int empid) {
            var query1 = deptlist.ToList();
            Employee emp = emplist.
                Where(x => x.EmployeeId == empid).FirstOrDefault();
            var query2 = emp;
            EmpDeptViewModel obj = new EmpDeptViewModel()
            {
                deptlist = query1,
                emp = query2,
                date = DateTime.Now
            };
            return View(obj); 
        }
        public IActionResult Details(int id)
        {
            var employee = emplist.FirstOrDefault(e=>e.EmployeeId== id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult searchemp(int empid)
        {
            Employee emp = (from e1 in emplist where e1.EmployeeId == empid select e1).FirstOrDefault();
            return View(emp);
        }
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

