namespace Dotnet_API.Models
{
    public class ProductVM
    {
        public string Name {get; set;}
        public double Price {get; set;}
    }
    public class Product:ProductVM
    {
        public Guid IdProduct{get; set;}
    }
}