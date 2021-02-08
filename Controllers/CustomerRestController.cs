using CatalogueApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers
{
    [Route("/api/customers")]
    public class CustomerRestController:Controller
    {
        public CatalogueRepository catalogueRepository {get; set;}

        public CustomerRestController(CatalogueRepository catalogueRepository){
            this.catalogueRepository  = catalogueRepository;
        }
        [HttpGet]
        public IEnumerable<Customer> ListCustomers(){
            return catalogueRepository.Customers.Include(c => c.Products);
        }

        [HttpGet("paginate")]
        public IEnumerable<Customer> GetListCustomers([FromQuery] int page = 0, [FromQuery] int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Customers.Include(c => c.Products).Skip(skipValue).Take(size);
        }

        [HttpPost]
        public Customer save([FromBody]Customer customer){
            catalogueRepository.Customers.Add(customer);
            catalogueRepository.SaveChanges();
            return customer;
        }

         [HttpGet("/api/customers/byName/{kw}")]
        public IEnumerable<Customer> search(string kw){
            return catalogueRepository.Customers.Where(c => c.Name.Contains(kw));
        }

        [HttpGet("/api/customers/byName/{kw}/paginate")]
        public IEnumerable<Customer> searchCusts(string kw, [FromQuery] int page = 0, [FromQuery] int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Customers.Where(c => c.Name.Contains(kw)).Skip(skipValue).Take(size);
        }

        [HttpGet("{Id}")]
        public Customer getCustomer(long Id){
            return catalogueRepository.Customers.FirstOrDefault(c => c.CustomerID==Id);
        }

         /*[HttpGet("{Id}/customers")]
        public IEnumerable<Product> products(long Id){
            Customer customer = catalogueRepository.Customers.Include(c => c.Products).FirstOrDefault(c => c.CustomerID==Id);
            return customer.Orders;
        }*/

        [HttpPut("{Id}")]
        public Customer update([FromBody]Customer customer, int Id){
            customer.CustomerID = Id;
            catalogueRepository.Customers.Update(customer);
            catalogueRepository.SaveChanges();
            return customer;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Customer customer = catalogueRepository.Customers.FirstOrDefault(c => c.CustomerID==Id);
            catalogueRepository.Customers.Remove(customer);
            catalogueRepository.SaveChanges();
        }
    }
}