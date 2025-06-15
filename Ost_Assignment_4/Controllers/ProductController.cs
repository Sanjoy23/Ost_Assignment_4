using Microsoft.AspNetCore.Mvc;
using Ost_Assignment_4.DTO;
using Ost_Assignment_4.Models;
using Ost_Assignment_4.Services;

namespace Ost_Assignment_4.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public IActionResult getProducts()
		{
			var products = new List<Product>();
			try {
				products = _productService.GetProducts();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok(products);
		}

		[HttpGet("{id}")]
		public IActionResult getProducts(int id)
		{
			var product = new Product();
			try
			{
				product = _productService.GetProducts(id);
				if (product == null)
				{
					return NotFound();
				}
			}
			catch(Exception ex){
				return BadRequest(ex.Message);
			}
			
			return Ok(product);
		}

		[HttpPost]
		public IActionResult Products([FromBody] ProductDto productDto)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(productDto.Name)) {
					return BadRequest();
				}
			   _productService.SaveProduct(productDto);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return StatusCode(201, "Product added successfully.");
		}
	}
}
