using Domain;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public void UpdatePhones(IEnumerable<Phone> entityObj)
        {
            var phoneUpdate = entityObj.Where(x => x.id > 0).ToList();
            var phoneInsert = entityObj.Where(x => x.id == 0).ToList();

            foreach (var phone in phoneUpdate)
            {
                customerDB.Entry(phone).State = EntityState.Modified;
                customerDB.SaveChanges();
            }

            foreach (var phone in phoneInsert)
            {
                customerDB.Set<Phone>().Add(phone);
                customerDB.SaveChanges();
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var courses = customerDB.Customer.Include(c => c.phones);
            return courses.ToList();
        }

        public void UpdateCustomer(Customer customerUpdate)
        {
            var customerExisting = customerDB.Customer
                .Where(p => p.cpf == customerUpdate.cpf)
                .Include(p => p.phones)
                .SingleOrDefault();

            if (customerExisting != null)
            {
                // Update customer
                customerDB.Entry(customerExisting).CurrentValues.SetValues(customerUpdate);

                // Delete phones
                foreach (var phonesExisting in customerExisting.phones.ToList())
                {
                    if (!customerUpdate.phones.Any(c => c.id == phonesExisting.id))
                        customerDB.Phone.Remove(phonesExisting);
                }

                // Update and insert phones
                foreach (var phoneNumber in customerUpdate.phones)
                {
                    if (phoneNumber.id == 0)
                    {
                        // Insert phone
                        var newPhone = new Phone
                        {
                            number = phoneNumber.number,
                            cpfCustomer = phoneNumber.cpfCustomer
                        };

                        customerExisting.phones.Add(newPhone);
                    }
                    else
                    {
                        var existingPhone = customerExisting.phones
                            .Where(c => c.id == phoneNumber.id)
                            .SingleOrDefault();

                        // Update phone
                        if (existingPhone != null)
                            customerDB.Entry(existingPhone).CurrentValues.SetValues(phoneNumber);
                    }                    
                }

                customerDB.SaveChanges();
            }
        }
    }
}
