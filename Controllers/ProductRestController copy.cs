using CatalogueApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace CatalogueApp.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("/api/products")]
    public class ProductRestController:Controller
    {
        public CatalogueRepository catalogueRepository {get; set;}

        public ProductRestController(CatalogueRepository catalogueRepository){
            this.catalogueRepository  = catalogueRepository;
        } 
        [HttpGet]
        public IEnumerable<Product> findAll(){
            return catalogueRepository.Products.Include(p => p.Category);
        }

         [HttpGet("paginate")]
        public IEnumerable<Product> page([FromQuery] int page = 0, [FromQuery] int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Products.Include(p => p.Category).Skip(skipValue).Take(size);
        }

        [HttpPost]
        public Product save([FromBody]Product product){
            catalogueRepository.Products.Add(product);
            catalogueRepository.SaveChanges();
            return product;
        }

        [HttpGet("{Id}")]
        public Product getProd(long Id){
            return catalogueRepository.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId==Id);
        }

        [HttpGet("/api/products/byCat/{categoryId}")]
        public IEnumerable<Product> getProdByCategory(long categoryId){
            return catalogueRepository.Products.Include(p => p.Category).Where(c => c.CategoryID==categoryId);
        }

        [HttpGet("/api/products/byCat/{categoryId}/paginate")]
        public IEnumerable<Product> getProductsByCategory(long categoryId, [FromQuery] int page = 0, [FromQuery] int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Products.Include(p => p.Category).Where(c => c.CategoryID==categoryId).Skip(skipValue).Take(size);
        }

        [HttpGet("/api/products/byName/{kw}")]
        public IEnumerable<Product> search(string kw){
            return catalogueRepository.Products.Include(p => p.Category).Where(p => p.Name.Contains(kw));
        }

        [HttpGet("/api/products/byName/{kw}/paginate")]
        public IEnumerable<Product> searchProds(string kw, [FromQuery] int page = 0, [FromQuery] int size = 1){
            int skipValue = (page - 1) * size;
            return catalogueRepository.Products.Include(p => p.Category).Where(p => p.Name.Contains(kw)).Skip(skipValue).Take(size);
        }

        [HttpPut("{Id}")]
        public Product update([FromBody]Product product, int Id){
            product.ProductId = Id;
            catalogueRepository.Products.Update(product);
            catalogueRepository.SaveChanges();
            return product;
        }
        
        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Product product = catalogueRepository.Products.FirstOrDefault(p => p.ProductId==Id);
            catalogueRepository.Products.Remove(product);
            catalogueRepository.SaveChanges();
        }
    }
}