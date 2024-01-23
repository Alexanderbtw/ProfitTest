using ProfitTest.Core.Models;

namespace ProfitTest.Core.Interfaces
{
    public interface IProductService
    {
        Task<Guid> AddAsync(Product product, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> FindAllByPriceAsync(decimal price, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> FindAllByTitleAsync(string title, CancellationToken cancellationToken = default);
        Task<Product?> FindFirstByTitleAsync(string title, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    }
}