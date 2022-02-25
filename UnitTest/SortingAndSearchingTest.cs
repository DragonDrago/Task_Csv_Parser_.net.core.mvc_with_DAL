using DAL;
using DAL.Entity;
using DAL.Services.SortinAndSearching;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class SortingAndSearchingTest
    {
        private readonly AppDbContext appDbContext;
        public SortingAndSearchingTest(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        SortingAndSearching sortingAndSearchingService;
      

        [SetUp]
        public void Setup()
        {
            sortingAndSearchingService = new SortingAndSearching();
        }
        [Test]
        public void ListForSearching_Works()
        {
            //Arrange
            var stringInput = "John";
            var users = new List<Employee>()
            {
                new Employee
                {
                    PayrollNumber ="1234",
                    Forenames="John",
                    Surname ="Doe",
                    DateOfBirth = DateTime.Now,
                    Telephone ="4596",
                    Mobile = "385622",
                    Address ="NY/Street/256",
                    Address2 ="CA/Street/146",
                    Postcode ="VW234",
                    EmailHome = "hello@gmail.com",
                    StartDate = DateTime.Now,
                },
                 new Employee
                {
                    PayrollNumber ="13334",
                    Forenames="Dave",
                    Surname ="Atkinson",
                    DateOfBirth = DateTime.Now,
                    Telephone ="444",
                    Mobile = "38132",
                    Address ="BR/Street/426",
                    Address2 ="CA/Street/146",
                    Postcode ="CA863",
                    EmailHome = "hi@gmail.com",
                    StartDate = DateTime.Now,
                },
                  new Employee
                {
                    PayrollNumber ="2345",
                    Forenames="Jack",
                    Surname ="Madny",
                    DateOfBirth = DateTime.Now,
                    Telephone ="1732",
                    Mobile = "275492",
                    Address ="ST/Street/996",
                    Address2 ="WA/Street/136",
                    Postcode ="CND653",
                    EmailHome = "perfect@gmail.com",
                    StartDate = DateTime.Now,
                }
            };
            //Act
            var searching = sortingAndSearchingService.ListForSearching(stringInput);

            //Assert
            Assert.That(stringInput, Is.EqualTo(searching= users.Where(n => n.Address.ToLower().Contains(stringInput.ToLower())
                  || n.DateOfBirth.ToString().ToLower().Contains(stringInput.ToLower())
                  || n.EmailHome.ToLower().Contains(stringInput.ToLower())
                  || n.Forenames.ToLower().Contains(stringInput.ToLower())
                  || n.Mobile.ToLower().Contains(stringInput.ToLower())
                  || n.PayrollNumber.ToLower().Contains(stringInput.ToLower())
                  || n.Postcode.ToLower().Contains(stringInput.ToLower())
                  || n.Surname.ToLower().Contains(stringInput.ToLower()))));
        }

        

    }
}
