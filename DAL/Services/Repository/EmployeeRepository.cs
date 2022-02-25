using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void AddEntity(Employee employee)
        {
            appDbContext.Add(employee);
            appDbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = appDbContext.Employees;
            return employees;
        }

        public Employee GetById(int id)
        {
            return appDbContext.Employees.Find(id);
        }

        public void Update(Employee updateEmployee)
        {
            var employee = appDbContext.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();
        }
    }
}
