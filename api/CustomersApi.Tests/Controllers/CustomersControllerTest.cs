using Api.Controllers;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Api.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTest
    {
        private Mock<ICustomerRepository> mockCustomerRepository;

        [TestInitialize]
        public void Initialize()
        {
            mockCustomerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        public void GetAllCustomersReturnsEverythingInRepository()
        {
            List<Customer> allCustomers = GetListCustomer();
            mockCustomerRepository.Setup(x => x.GetCustomers()).Returns(allCustomers);
            ICustomerRepository repository = mockCustomerRepository.Object;
      
            CustomersController controller = new CustomersController(repository);         
            IEnumerable<Customer> result = controller.Get();

            Assert.AreSame(allCustomers, result);
        }

        [TestMethod]
        public void GetCustomerReturnsCorrectItemFromRepository()
        {
            var customer = new Customer()
                {
                    name = "Carlos Lucas Brandão",
                    cpf = "06289545450",
                    email = "carlos@gmail.com",
                    maritalStatus = "single",
                    address = "Rua Campina Verder, 250"

                };

            mockCustomerRepository.Setup(x => x.GetById(customer.cpf)).Returns(customer);
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            Customer result = controller.Get("06289545450");

            Assert.AreSame(customer, result);
        }

        [TestMethod]
        public void GetCustomerRepositoryReturnsNull()
        {
            var customer = new Customer();

            mockCustomerRepository.Setup(x => x.GetById(customer.cpf)).Returns(customer);
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            Customer result = controller.Get("1");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void PostCustomerReturnsCreatedStatusCode()
        {
            var customer = new Customer()
            {
                cpf = "06269985650",
            };

            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.Created);

            var result = controller.Post(customer);

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void PostCustomerReturnsInternalServerErrorStatusCode()
        {
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.InternalServerError);

            var result = controller.Post(new Customer());

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void PutCustomerReturnsOkStatusCode()
        {
            var customer = new Customer()
            {
                cpf = "06269985650",
                name = "Carlos Lucas Brandão",
            };

            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.OK);

            var result = controller.Put("1", customer);

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void PutCustomerReturnsInternalServerErrorStatusCode()
        {
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.InternalServerError);

            var result = controller.Put("0", null);

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void DeleteCustomerReturnsOkStatusCode()
        {
            var customer = new Customer()
            {
                cpf = "06269985650",
                name = "Carlos Lucas Brandão",
            };

            mockCustomerRepository.Setup(x => x.GetById(customer.cpf)).Returns(customer);
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.OK);

            var result = controller.Delete("06269985650");

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public void DeleteCustomerReturnsInternalServerErrorStatusCode()
        {
            ICustomerRepository repository = mockCustomerRepository.Object;

            CustomersController controller = new CustomersController(repository);
            controller.Request = new HttpRequestMessage();
            HttpResponseMessage response = controller.Request.CreateResponse(HttpStatusCode.InternalServerError);

            var result = controller.Delete("1");

            Assert.AreEqual(response.StatusCode, result.StatusCode);
        }

        private static List<Customer> GetListCustomer()
        {
            List<Customer> customersMock = new List<Customer>();

            var phones1 = new List<Phone>();
            phones1.Add(new Phone() { id = 1, number = 3133571909, cpfCustomer = "06289545450" });
            phones1.Add(new Phone() { id = 2, number = 31987841244, cpfCustomer = "06289545450" });
            phones1.Add(new Phone() { id = 3, number = 31991490363, cpfCustomer = "06289545450" });

            customersMock.Add(
                new Customer()
                {
                    name = "Carlos Lucas Brandão",
                    cpf = "06289545450",
                    email = "carlos@gmail.com",
                    maritalStatus = "single",
                    address = "Rua Campina Verder, 250",
                    phones = phones1

                });

            var phones2 = new List<Phone>();
            phones2.Add(new Phone() { id = 2, number = 31999993919, cpfCustomer = "00429545450" });

            customersMock.Add(
                new Customer()
                {
                    name = "Joao da Silva",
                    cpf = "00429545450",
                    email = "jose@gmail.com",
                    maritalStatus = "single",
                    address = "Rua Campina Verder, 250",
                    phones = phones2

                });
            return customersMock;
        }
    }
}
