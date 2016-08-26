
using Domain;
using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository
{
    public class ContextCustomerDb : DbContext
    {
        public ContextCustomerDb()
            : base("DbCustomer")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Phone> Phone { get; set; }
    }
}
