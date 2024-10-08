﻿namespace Service.Application.Products;

public class ProductById
{
	public int Id { get; set; }
	public string Name { get; private set; }
	public string Type { get; private set; }
	public int AllowedConsumption { get; private set; }
	public decimal BaseCost { get; private set; }
	public decimal CostPerKWh { get; private set; }
}
