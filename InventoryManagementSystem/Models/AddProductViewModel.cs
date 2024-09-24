namespace InventoryManagementSystem.Models
{
    public class AddProductViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
