using FastShop.Dtos.Requests;

namespace FastShop.API.Extensions
{
    public static class CommonExtensions
    {      
        public static string ErrorDeleteMessage(int id)
        {
            return ($"{id} id'li ürün silinmiştir!");            
        }
        public static string AddSuccessfulMessage(AddProductRequest request)
        {
            return ($"{request.ProductName} Adlı Ürün Başarıyla Eklenmiştir!");
        }
        public static string UpdateSuccessfulMessage(UpdateProductRequest request,int id)
        {
            return ($"{id} id'li {request.ProductName} Adlı Ürün Başarıyla Güncellenmiştir!");
        }
       
    }
}
