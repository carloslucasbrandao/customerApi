using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors(origins: "http://localhost:52711", headers: "*", methods: "*")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository repository)
        {
            customerRepository = repository;
        }

        public IEnumerable<Customer> Get()
        {
            var listCustomer = customerRepository.GetCustomers();
            return listCustomer;
        }

        public Customer Get(string id)
        {
            var customer = customerRepository.GetById(id);            
            return customer;
        }

        public HttpResponseMessage Post(Customer customer)
        {
            HttpResponseMessage response;
            try
            {
                if (customer == null || !Utils.IsCpf(customer.cpf))
                    throw new Exception();

                customerRepository.Add(customer);
                response = Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (System.Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public HttpResponseMessage Put(string id, Customer customer)
        {
            HttpResponseMessage response;
            try
            {
                if (customer == null || !Utils.IsCpf(customer.cpf))
                    throw new Exception();

                customerRepository.UpdateCustomer(customer);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage response;
            try
            {
                var customer = customerRepository.GetById(id);

                if (customer == null)
                    throw new Exception();   
 
                customerRepository.Remove(customer);
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;            
        }
    }
}
