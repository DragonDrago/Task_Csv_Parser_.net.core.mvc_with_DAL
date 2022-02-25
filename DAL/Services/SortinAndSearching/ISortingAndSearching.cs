using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.SortinAndSearching
{
    public interface ISortingAndSearching
    {
        // To make loosely coupled classes, and to write clean code we use interface segregation accoring to SOLID princeples, adn later to use dependency injection in our classes.
        IEnumerable<Employee> ListForSortByAsc(string sortBy);
        IEnumerable<Employee> ListForSortByDesc(string sortBy);
        IEnumerable<Employee> ListForSearching(string searchString);
    }
}
