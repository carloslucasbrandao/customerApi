namespace Repository.Migrations
{
    using Domain;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.ContextCustomerDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.ContextCustomerDb context)
        {
            context.Customer.AddOrUpdate(p => p.name,
               new Customer
               {
                   cpf = "06269985650",
                   name = "Debrora Garcia",
                   address = "1234 Main St",                   
                   email = "debra@gmail.com",
                   maritalStatus = "Single",
                   phones = new List<Phone>() { new Phone { number = 3133571909 } }
               },

               new Customer
               {
                   cpf = "06972750601",
                   name = "Alex Gates",
                   address = "1234 Main St",                   
                   email = "alex@gmail.com",
                   maritalStatus = "Single",
                   phones = new List<Phone>() { new Phone { number = 31991490363 } }
               }
            );
        }
    }
}
