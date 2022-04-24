using FastShop.Dtos.Responses;
using System.Collections.Generic;
using System.Linq;

namespace FastShop.Web.Models
{
    
    public class CartCollection
    {
        public int Shipping { get; set; } = 50;
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public void Add(CartItem item)
        {
            var findItem = CartItems.Find(x =>x.Product.ProductId == item.Product.ProductId);
            if(findItem == null)
            {
                CartItems.Add(item);
            }
            else
            {
                findItem.Quantity += item.Quantity;
            }
        }
        public double GetSubTotal()
        {
            return CartItems.Sum(x => (((double)x.Product.UnitPrice)) * (1 - x.Product.Discount.Value) * x.Quantity ) ;
        }
        public double GetTotalPrice()
        {
            return CartItems.Sum(x => (((double)x.Product.UnitPrice)) * (1-x.Product.Discount.Value)* x.Quantity) + Shipping;
        }
        public void ClearAll()
        {
            CartItems.Clear();
        }
        public void Delete(int id)
        {
            CartItems.RemoveAll(x=>x.Product.ProductId == id);
        }
    }
}
