namespace Dotnet_API.Data
{
    public enum StatusOrder{
        New = 0,
        Payment = 1,
        Complete =2,
        Cancel = -1
    }
    public class Order
    {
        public Guid IdOrder{get; set;}
        public DateTime DateOrder {get;set;}
        public DateTime DateDelivery {get; set;}
        public string PhoneNumber {get; set;}
        public string NameCus {get; set;}
        public string AddressCus{get; set;}
        public StatusOrder StatusOrder {get; set;}

        public ICollection<OrderDetail> OrderDetails {get; set;}
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }


    }
}