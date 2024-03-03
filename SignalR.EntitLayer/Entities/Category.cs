namespace SignalRApi.EntityLayer.Entities
{
    public class Category
    {
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }

        public bool Status { get; set; }
        public List<Product> Products { get; set; }

    }
}
