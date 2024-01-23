using ProfitTest.Core.Interfaces;

namespace ProfitTest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProductDbContext _context;
        public IProductRepository Products { get; }

        public UnitOfWork(ProductDbContext context)
        {
            _context = context;

            Products = new ProductRepository(context);
        }

        public async Task<bool> SaveChangesAsync()
        {
            var res = await _context.SaveChangesAsync().ConfigureAwait(false);
            return res > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
