using FastShop.Entities.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Entities.Concrete
{
    public class Product:IEntity
    {   
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }      
        public decimal UnitPrice { get; set; }
        public int? Stock { get; set; }
        public double? Discount { get; set; } 
        public DateTime? CreatedDate { get; set; }    
        public DateTime? ModifiedDate { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
