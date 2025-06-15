using Ost_Assignment_4.DTO;
using Ost_Assignment_4.Models;
using System.Data;
using System.Data.SqlClient;

namespace Ost_Assignment_4.Services
{
	public class ProductService
	{
		private readonly IConfiguration _configuration;

		public ProductService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public List<Product> GetProducts()
		{
			List<Product> products = new List<Product>();
			string connectionString = _configuration.GetConnectionString("DefaultConnection");
			var connection = new SqlConnection(connectionString);
			connection.Open();
			string commandText = "Select * from Products";
			SqlCommand cmd = new SqlCommand(commandText, connection);
			cmd.CommandTimeout = 0;
			cmd.CommandType = CommandType.Text;
			cmd.Parameters.Clear();

			SqlDataReader reader = cmd.ExecuteReader();
			if (reader != null)
			{
				while (reader.Read())
				{
					Product product = new Product();
					product.Id = Convert.ToInt32(reader["Id"]);
					product.Name = reader["Name"].ToString();
					product.Quantity = Convert.ToInt32(reader["Quantity"]);
					product.Price = Convert.ToDouble(reader["Price"]);
					products.Add(product);
				}
			}
			cmd.Dispose();
			connection.Close();
			return products;
		}

		public Product GetProducts(int Id)
		{
			Product? product = null;
			string connectionString = _configuration.GetConnectionString("DefaultConnection");
			var connection = new SqlConnection(connectionString);
			connection.Open();
			string commandText = "sp_FindProductById";
			SqlCommand cmd = new SqlCommand(commandText, connection);
			cmd.CommandTimeout = 0;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("Id", Id);

			SqlDataReader reader = cmd.ExecuteReader();
			if (reader != null)
			{
				while (reader.Read()) {
					product = new Product
					{
						Id = Convert.ToInt32(reader["Id"]),
						Name = reader["Name"].ToString(),
						Quantity = Convert.ToInt32(reader["Quantity"]),
						Price = Convert.ToDouble(reader["Price"])
					};
				}
			}
			cmd.Dispose();
			connection.Close();
			return product;
		}

		public void SaveProduct(ProductDto productDto)
		{
			string connectionString = _configuration.GetConnectionString("DefaultConnection");
			var connection = new SqlConnection(connectionString);
			connection.Open();
			string commandText = "sp_InsertProduct";
			SqlCommand cmd = new SqlCommand(commandText, connection);
			cmd.CommandTimeout = 0;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("Name", productDto.Name);
			cmd.Parameters.AddWithValue("Quantity", productDto.Quantity);
			cmd.Parameters.AddWithValue("Price", productDto.Price);

			SqlDataReader reader = cmd.ExecuteReader();
			
			cmd.Dispose();
			connection.Close();
		}
	}
}
