namespace FastShop.API.Extensions
{
    public static class CommonExtensions
    {      
        public static string ErrorDeleteMessage(int id)
        {
            return ($"{id}'li ürün silinmiştir!");            
        }
    }
}
