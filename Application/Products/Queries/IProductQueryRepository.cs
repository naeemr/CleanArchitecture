
using Domain.ProductAggregate;

namespace Application.Products.Queries;

public interface IProductQueryRepository : IBaseRepository<Product>
{
    /// <summary>
    /// Get All products from database
    /// </summary>
    /// <returns>list of products</returns>
    Task<List<Product>> GetProducts();
}
