using Web_DemoMVCWithEFCoreCodeFirst.Repositories;

namespace Web_DemoMVCWithEFCoreCodeFirst.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Products { get; }
        Task<int> CommitChangesAsync();
    }
}
