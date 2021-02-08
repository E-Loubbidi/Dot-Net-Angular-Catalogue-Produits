using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CatalogueApp.Model
{
    public class Customer
    {
        public Customer(){
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int CustomerID {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        //[JsonIgnore]
        public virtual ICollection<Product> Products {get; set;}
    }
}