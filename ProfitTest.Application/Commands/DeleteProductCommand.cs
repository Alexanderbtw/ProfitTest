using MediatR;

namespace ProfitTest.Application.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id) 
        {
            Id = id;
        }
    }
}
