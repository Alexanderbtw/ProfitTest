namespace ProfitTest.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        Task<bool> SaveChangesAsync();
    }
}
