namespace Application.Products.Queries;

public class ProductDTO
{
    public string Name { get; private set; }
    public decimal AnnualCost { get; private set; }

    public ProductDTO(string name, decimal annualCost)
    {
        Name = name;
        AnnualCost = annualCost;
    }
}
