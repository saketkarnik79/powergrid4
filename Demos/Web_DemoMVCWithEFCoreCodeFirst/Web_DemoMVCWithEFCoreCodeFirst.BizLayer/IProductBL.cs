using Web_DemoMVCWithEFCoreCodeFirst.Models;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;

namespace Web_DemoMVCWithEFCoreCodeFirst.BizLayer
{
    public interface IProductBL
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(long id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(long id);
    }
}
