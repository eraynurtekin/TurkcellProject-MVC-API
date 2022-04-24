using FastShop.Dtos.Responses;
using System.Collections.Generic;
using System.Linq;

namespace FastShop.Web.Models
{

    public class CartItem
    {
        public ProductListResponse Product { get; set; }
        public int Quantity { get; set; }
       
        public CartCollection CartCollection { get; set; }
    }

}
