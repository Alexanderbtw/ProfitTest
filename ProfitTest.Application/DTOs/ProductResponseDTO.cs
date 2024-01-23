namespace ProfitTest.Application.DTOs
{
    public class ProductResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public float Weight { get; set; }
    }
}
