using MediatR;
using ProfitTest.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProfitTest.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Range(0, uint.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, uint.MaxValue)]
        public float Weight { get; set; }
    }
}
