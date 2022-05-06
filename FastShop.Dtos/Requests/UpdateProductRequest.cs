using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastShop.Dtos.Requests
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ürün adını boş bırakmayınız")]
        [MinLength(3, ErrorMessage = "Ürün adı en az üç karakter olmalıdır")]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        public double? UnitPrice { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
