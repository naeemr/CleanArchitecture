using Domain.ProductAggregate;

namespace Application.Products;

public interface IProductRepository : IBaseRepository<Product>
{
    /// <summary>
    /// Adds new product async
    /// </summary>
    /// <param name="product">product that need to be added</param>  
    /// <returns>updated product</returns>
    Task<Product> AddProduct(Product product);

    /// <summary>
    /// Get All products from database
    /// </summary>
    /// <returns>list of products</returns>
    Task<List<Product>> GetProducts();
}
