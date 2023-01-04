namespace Dotnet_API.Data
{
    public class OrderDetail
    {
        public Guid Id{get; set;}
        public Guid IdOrder {get; set;}
        public int Quantity {get; set;}
        public double Price {get; set;}
        public byte Sale {get; set;}
        
        public Order Order {get; set;}
        public Product Product {get; set;}
    }
}