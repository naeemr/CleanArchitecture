using Application.Products.Commands;
using Domain.ProductAggregate;

namespace Infrastructure.Persistence.Commands;

public class ProductCommandRepository : IProductCommandRepository
{
    private readonly ApplicationDbContext _context;

    public ProductCommandRepository(ApplicationDbContext dbContext)
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
}
