using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services.Csv_Paring
{
    public class CsvParser:ICsvParser
    {
        //This method accepts argument oftype file, after, it reads the parsing reasult to lislt of objects (IEnumerable<Employee>) then returns it.
        IEnumerable<Employee> ICsvParser.CsvParser(IFormFile formFile)
        {
            MemoryStream stream = new MemoryStream();
            formFile.CopyTo(stream);
            byte[] bufferMemory = stream.ToArray();

            List<Employee> result = new List<Employee>();

            using (StreamReader sr = new StreamReader(new MemoryStream(bufferMemory)))
            {
                string headerLine = sr.ReadLine();
                string eachLine;
                while ((eachLine = sr.ReadLine()) != null)
                {
                    Employee user = new Employee();
                    user.PayrollNumber = eachLine.Split(',')[0];
                    user.Forenames = eachLine.Split(',')[1];
                    user.Surname = eachLine.Split(',')[2];
                    user.DateOfBirth = Convert.ToDateTime(DateTimeCorrector(eachLine.Split(',')[3]));
                    user.Telephone = eachLine.Split(',')[4];
                    user.Mobile = eachLine.Split(',')[5];
                    user.Address = eachLine.Split(',')[6];
                    user.Address2 = eachLine.Split(',')[7];
                    user.Postcode = eachLine.Split(',')[8];
                    user.EmailHome = eachLine.Split(',')[9];
                    user.StartDate = Convert.ToDateTime(DateTimeCorrector(eachLine.Split(',')[3]));
                    result.Add(user);
                }


            }
            return result;
        }
        //This method corrects datetime for entity Model(Employee) format that coming from parsing result.
        public string DateTimeCorrector(string value)
        {
            var newValue = value.Split('/');
            value = newValue[1] + "/" + newValue[0] + "/" + newValue[2];
            return value;
        }
    }
}
