namespace Application.Products.Queries;

public class GetProducts
{
    public string Name { get; private set; }
    public decimal AnnualCost { get; private set; }

    public GetProducts(string name, decimal annualCost)
    {
        Name = name;
        AnnualCost = annualCost;
    }
}
