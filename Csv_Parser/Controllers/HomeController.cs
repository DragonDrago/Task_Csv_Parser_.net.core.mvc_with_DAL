using Csv_Parser.Models;
using DAL.Entity;
using DAL.Services.Csv_Paring;
using DAL.Services.Repository;
using DAL.Services.SortinAndSearching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Csv_Parser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICsvParser csvParser;
        private readonly ISortingAndSearching sortingAndSearching;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository, ICsvParser csvParser, ISortingAndSearching sortingAndSearching)
        {
            _logger = logger;
            this.employeeRepository = employeeRepository;
            this.csvParser = csvParser;
            this.sortingAndSearching = sortingAndSearching;
        }


        public IActionResult SortByAsc(string value)
        {
            var model = sortingAndSearching.ListForSortByAsc(value);
            return View("Index", model);
        }

        public IActionResult SortByDesc(string value)
        {
            var model = sortingAndSearching.ListForSortByDesc(value);
            return View("Index", model);
        }

        public IActionResult Searching(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var model = sortingAndSearching.ListForSearching(searchString);
                return View("Index", model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var employees = employeeRepository.GetAll().OrderBy(x => x.Surname).ToList();
            return View(employees);
        }


        [HttpPost]
        public IActionResult AddingCsvFile(IFormFile csv_file)
        {
            int rowCount = 0;
            List<Employee> employees = new List<Employee>();

            if (csv_file != null)
            {
                employees = csvParser.CsvParser(csv_file).ToList();
            }
            else
            {
                return View("NotFound");
            }

            foreach (var employee in employees)
            {
                employeeRepository.AddEntity(employee);
                rowCount++;
            }

            return View(rowCount);
        }

        public IActionResult Edit(int id)
        {
            var employee = employeeRepository.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee existingEmployee = employeeRepository.GetById(employee.Id);
                existingEmployee.Surname = employee.Surname;
                existingEmployee.PayrollNumber = employee.PayrollNumber;
                existingEmployee.Forenames = employee.Forenames;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Telephone = employee.Telephone;
                existingEmployee.Mobile = employee.Mobile;
                existingEmployee.Address = employee.Address;
                existingEmployee.Address2 = employee.Address2;
                existingEmployee.Postcode = employee.Postcode;
                existingEmployee.EmailHome = employee.EmailHome;
                existingEmployee.StartDate = employee.StartDate;
                employeeRepository.Update(existingEmployee);

            }
            else
            {
                return View();
            }


            return RedirectToAction(nameof(Index));
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
