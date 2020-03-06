using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACEntrepidusTest.Models
{
    public class DBInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        public const string sAddress1 =
@"Avenida principal con calle 1
casa N. 54";

        public const string sAddress2 =
@"Avenida 2 con calle 3
casa N. 147";

        protected override void Seed(ApplicationDbContext context)
        {
            IList<Employee> defaultEmployees = new List<Employee>();

            defaultEmployees.Add(new Employee() { 
                FullName = "Alfredo Castro", 
                DocumentId = "V-12689895", 
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278",
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Luke Skywalker",
                DocumentId = "V-11222333",
                BirthDate = new DateTime(1970, 01, 15),
                ContractDate = new DateTime(2019, 12, 15),
                Address = sAddress2,
                PhoneNumber = "5555-222-3333",
                EMail = "alcastronava@gmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Obi Wan Kenobi",
                DocumentId = "V-10333444",
                BirthDate = new DateTime(1960, 02, 17),
                ContractDate = new DateTime(2019, 11, 15),
                Address = sAddress1,
                PhoneNumber = "5555-222-3333"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });
            defaultEmployees.Add(new Employee()
            {
                FullName = "Alfredo Castro",
                DocumentId = "V-12689895",
                BirthDate = new DateTime(1974, 09, 16),
                ContractDate = new DateTime(2020, 01, 15),
                Address = sAddress1,
                PhoneNumber = "0412-219-4278"
                EMail = "alcastronava@hotmail.com",
                IsFreelance = true,
                PayRate = 15.00M
            });

            context.Employees.AddRange(defaultEmployees);

            base.Seed(context);
        }
    }
}