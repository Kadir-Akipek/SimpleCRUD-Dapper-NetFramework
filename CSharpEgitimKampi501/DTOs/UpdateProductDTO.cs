﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi501.DTOs
{
	public class UpdateProductDTO
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductCategory { get; set; }
		public int ProductStock { get; set; }

		public decimal ProductPrice { get; set; }
	}
}
