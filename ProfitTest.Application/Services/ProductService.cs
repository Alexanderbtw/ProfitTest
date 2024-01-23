using ProfitTest.Core.Interfaces;
using ProfitTest.Core.Models;

namespace ProfitTest.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> FindAllByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.FindAllAsync(prod => prod.Title == title, cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> FindAllByPriceAsync(decimal price, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.FindAllAsync(prod => prod.Price == price, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.GetAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Product?> FindFirstByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.FindAsync(prod => prod.Title == title, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Guid> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            Product res = await _unitOfWork.Products.AddAsync(product, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return res.Id;
        }

        public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Products.RemoveAsync(id, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Guid> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            Product res = _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return res.Id;
        }
    }
}
