﻿namespace Service.Application.Products;

public interface IProductUseCase
{
	/// <summary>
	/// Get products by calculating annual cost based on required consumption
	/// </summary>
	/// <param name="consumption">consumption KWh/year</param>
	/// <returns>list of products</returns>
	Task<List<ProductModel>> GetProducts(int consumption);

	/// <summary>
	/// Get product by id
	/// </summary>
	/// <param name="id">product id</param>
	/// <returns>product dto</returns>
	Task<ProductById> GetProductById(int id);
}
