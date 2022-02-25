using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Repository
{
    public interface IEmployeeRepository
    {
        // To make loosely coupled classes, and to write clean code we use interface segregation accoring to SOLID princeples, adn later to use dependency injection in our classes.
        void AddEntity(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Update(Employee employee);
    }
}
