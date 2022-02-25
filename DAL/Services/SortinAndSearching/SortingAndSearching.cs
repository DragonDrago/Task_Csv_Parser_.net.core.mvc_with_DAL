using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.SortinAndSearching
{
    public class SortingAndSearching:ISortingAndSearching
    {
        private readonly AppDbContext appDbContext;

        public SortingAndSearching()
        {
        }

        public SortingAndSearching(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //it returns sorted list by checking with given argument to the method.
        public IEnumerable<Employee> ListForSearching(string searchString)
        {
            var employees = appDbContext.Employees.ToList();
            var filterResult = employees.Where(n => n.Address.ToLower().Contains(searchString.ToLower())
                 || n.DateOfBirth.ToString().ToLower().Contains(searchString.ToLower())
                 || n.EmailHome.ToLower().Contains(searchString.ToLower())
                 || n.Forenames.ToLower().Contains(searchString.ToLower())
                 || n.Mobile.ToLower().Contains(searchString.ToLower())
                 || n.PayrollNumber.ToLower().Contains(searchString.ToLower())
                 || n.Postcode.ToLower().Contains(searchString.ToLower())
                 || n.Surname.ToLower().Contains(searchString.ToLower()));
            return filterResult;
        }

        //It sorts all employees in Db by given parameters , and return List of Employee that sorted by Ascending order
        public IEnumerable<Employee> ListForSortByAsc(string sortBy)
        {
            IEnumerable<Employee> employees = new List<Employee>();
            switch (sortBy)
            {
                case "PayrollNumber":
                    employees = appDbContext.Employees.OrderBy(n => n.PayrollNumber).ToList();
                    break;
                case "Forenames":
                    employees = appDbContext.Employees.OrderBy(n => n.Forenames).ToList();
                    break;
                case "DateOfBirth":
                    employees = appDbContext.Employees.OrderBy(n => n.DateOfBirth).ToList();
                    break;
                case "Telephone":
                    employees = appDbContext.Employees.OrderBy(n => n.Telephone).ToList();
                    break;
                case "EmailHome":
                    employees = appDbContext.Employees.OrderBy(n => n.EmailHome).ToList();
                    break;
            }
            return employees;
        }

        //It sorts all employees in Db by given parameters , and return List of Employee that sorted by Descending order
        public IEnumerable<Employee> ListForSortByDesc(string sortBy)
        {
            IEnumerable<Employee> employees = new List<Employee>();
            switch (sortBy)
            {
                case "PayrollNumber":
                    employees = appDbContext.Employees.OrderByDescending(n => n.PayrollNumber).ToList();
                    break;
                case "Forenames":
                    employees = appDbContext.Employees.OrderByDescending(n => n.Forenames).ToList();
                    break;
                case "DateOfBirth":
                    employees = appDbContext.Employees.OrderByDescending(n => n.DateOfBirth).ToList();
                    break;
                case "Telephone":
                    employees = appDbContext.Employees.OrderByDescending(n => n.Telephone).ToList();
                    break;
                case "EmailHome":
                    employees = appDbContext.Employees.OrderByDescending(n => n.EmailHome).ToList();
                    break;
            }
            return employees;
        }
    }
}
