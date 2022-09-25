using Application.Products;
using Domain.ProductAggregate;

namespace Infrastructure.Persistence.Queries;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    /// <summary>
    /// Adds new object async
    /// </summary>
    /// <param name="entity">object that need to be added</param>  
    /// <returns>Task.</returns>
    public async Task<Product> AddProduct(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        var entities = _context.Products.ToList();

        return await Task.FromResult(entities);
    }
}
