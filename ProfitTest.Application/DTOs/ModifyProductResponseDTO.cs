namespace ProfitTest.Application.DTOs
{
    public class ModifyProductResponseDTO
    {
        public Guid? ProductId { get; set; } = null;
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }
}
