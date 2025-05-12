namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }               // Primary key
        public string? Product { get; set; }      // Product name or ID
        public int Quantity { get; set; }        // Quantity ordered
        public DateTime OrderDate { get; set; }  // Timestamp
                                                 
    }
}
