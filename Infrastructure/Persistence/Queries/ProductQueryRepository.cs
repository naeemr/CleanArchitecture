using Application.Products.Queries;
using Domain.ProductAggregate;

namespace Infrastructure.Persistence.Queries;

public class ProductQueryRepository : IProductQueryRepository
{
    private readonly ApplicationDbContext _context;

    public ProductQueryRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<Product>> GetProducts()
    {
        var entities = _context.Products.ToList();

        return await Task.FromResult(entities);
    }
}
