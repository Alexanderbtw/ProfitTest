namespace ProfitTest.Core.Interfaces.DAL
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        Task<bool> SaveChangesAsync();
    }
}
