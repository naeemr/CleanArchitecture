using Domain.ProductAggregate;

namespace Application.Products.Commands;

public interface IProductCommandRepository : IBaseRepository<Product>
{
    /// <summary>
    /// Adds new product async
    /// </summary>
    /// <param name="product">product that need to be added</param>  
    /// <returns>updated product</returns>
    Task<Product> AddProduct(Product product);
}
