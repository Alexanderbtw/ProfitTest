using OrderDelivery.DAL.Repositories;
using ProfitTest.Core.Interfaces.DAL;
using ProfitTest.Core.Models;

namespace ProfitTest.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product, ProductDbContext>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context) { }
    }
}
