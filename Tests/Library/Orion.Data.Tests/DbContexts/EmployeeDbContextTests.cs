using System;
using System.Linq;
using Orion.Data.DbContexts;
using Orion.Data.Entities;
using Xunit;
using static Xunit.Assert;

namespace Orion.Data.Tests.DbContexts
{
    public class EmployeeDbContextTests
    {
        [Fact]
        public void AddEmployee() {
           var firstCount = 0;
           var lastCount = 0;

            using (var c = new EmployeeDbContext()) {
                firstCount = c.Employees.Count();

                c.Employees.Add(CreateDefaultEmployeeWithNumber(1));
                c.SaveChanges();

                lastCount = c.Employees.Count();
            }

            Equal(firstCount + 1, lastCount);
        }

        [Fact]
        public void Add1000Employees() {
            var firstCount = 0;
            var lastCount = 0;

            using (var c = new EmployeeDbContext())
            {
                firstCount = c.Employees.Count();

                for(var i = 2; i < 1002; i++)
                    c.Employees.Add(CreateDefaultEmployeeWithNumber(i));
                
                c.SaveChanges();

                lastCount = c.Employees.Count();
            }

            Equal(firstCount + 1000, lastCount);
        }

        private Employee CreateDefaultEmployeeWithNumber(int number) {
            return new Employee {
                Id = Guid.NewGuid(),
                FirstName = $"Employee {number} FirstName",
                LastName = $"Employee {number} LastName",
                MiddleName = $"Employee {number} MiddleName"
            };
        }
    }
}
