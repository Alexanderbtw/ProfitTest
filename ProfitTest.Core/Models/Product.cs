namespace ProfitTest.Core.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public float Weight { get; set; }
    }
}
