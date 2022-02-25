using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Payroll number")]
        [Required(ErrorMessage = "PayrollNumber is Required")]
        public string PayrollNumber { get; set; }

        [Display(Name = "Forenames")]
        [Required(ErrorMessage = "Forenames is Required")]
        public string Forenames { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname is Required")]
        public string Surname { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "DateOfBirth is Required")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string Mobile { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "Postcode")]
        [Required(ErrorMessage = "Postcode is Required")]
        public string Postcode { get; set; }

        [Display(Name = "Email home")]
        [Required(ErrorMessage = "Home Email is Required")]
        public string EmailHome { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = "StartDate is Required")]
        public DateTime StartDate { get; set; }
    }
}
