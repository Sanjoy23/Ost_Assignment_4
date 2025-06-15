using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Ost_Assignment_4.Models
{
	public class Product
	{
		public int Id { get; set; }

		public string Name {  get; set; } = string.Empty;

		public int Quantity { get; set; }

		public double Price { get; set; }
	}


}
