using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CatalogueApp.Model
{
    public class Product
    {
        public Product(){
            this.Customers = new HashSet<Customer>();
        }

        public int ProductId {get; set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public string[] Characteristics {get; set;}
        public int CategoryID {get; set;}
        [ForeignKey("CategoryID")]
        public virtual Category Category {get; set;}
        [JsonIgnore]
        public virtual ICollection<Customer> Customers {get; set;}
    }
}