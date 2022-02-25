using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Csv_Paring
{
    public interface ICsvParser
    {
        IEnumerable<Employee> CsvParser(IFormFile formFile);
    }
}
