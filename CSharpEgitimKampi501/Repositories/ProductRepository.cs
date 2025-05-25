using CSharpEgitimKampi501.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public Task CreateProductAsync(CreateProductDTO createProductDTO)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ResultProductDTO>> GetAllProductAsync()
		{
			throw new NotImplementedException();
		}

		public Task GetByProductIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
		{
			throw new NotImplementedException();
		}
	}
}
