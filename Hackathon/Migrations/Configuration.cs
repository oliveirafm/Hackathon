namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hackathon.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Hackathon.Models.ApplicationDbContext context)
        {
            context.BankAccounts.AddOrUpdate(
                p => p.BankAccountId,
                new Models.BankAccount { AccountBalance = 200, currentYearPensionRetained=100, currentYearTaxRetained=10, currentYearRentingRetained = 5}
                );

            context.ExchangeServices.AddOrUpdate(
                p=> p.ExchangeServiceId,
                new Models.ExchangeService { ExchangeServiceName = "Pension", AvailableInMarket=true},
                new Models.ExchangeService { ExchangeServiceName = "Live Insurance", AvailableInMarket = true },
                new Models.ExchangeService { ExchangeServiceName = "Renting (Auto)", AvailableInMarket = true },
                new Models.ExchangeService { ExchangeServiceName = "Telecom", AvailableInMarket = true }
                );

            context.Customers.AddOrUpdate(
                p => p.CustomerId,
                new Models.Customer { CustomerName = "Lab 15", CustomerVatNumber = 11111111, CustomerEmail="filipe@six-factor.com" },
                new Models.Customer { CustomerName = "Six Factor", CustomerVatNumber = 513667601, CustomerEmail = "ivo@six-factor.com" }
                );

        }
    }
}
