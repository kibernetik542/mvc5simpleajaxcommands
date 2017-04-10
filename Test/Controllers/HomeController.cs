using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult All()
        {
            Thread.Sleep(3000);
            List<Employee> model = db.Employees.ToList();
            return PartialView("_Employee", model);
        }


        public PartialViewResult Top3()
        {
            Thread.Sleep(3000);
            List<Employee> model = db.Employees
                .OrderByDescending(x => x.Salary).Take(3).ToList();
            return PartialView("_Employee", model);
        }

        public PartialViewResult Bottom3()
        {
            Thread.Sleep(3000);
            List<Employee> model = db.Employees
                .OrderBy(x => x.Salary).Take(3).ToList();
            return PartialView("_Employee", model);
        }



    }
}