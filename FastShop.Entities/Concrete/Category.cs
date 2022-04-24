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
    public class Category:IEntity
    {
    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; } = true;
        public ICollection<Product> Products { get; set; }
    }
}
