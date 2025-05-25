using CSharpEgitimKampi501.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.Repositories
{
	public interface IProductRepository
	{
		Task<List<ResultProductDTO>> GetAllProductAsync();
		Task CreateProductAsync(CreateProductDTO createProductDTO);
		Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
		Task DeleteProductAsync(int id);
		Task GetByProductIdAsync(int id);
		
	}
}
