using SignalR.EntityLayer.Entities;

namespace SignalRApi.EntityLayer.Entities
{
    public class Product
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }


        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> orderDetails { get; set; }


    }
}
