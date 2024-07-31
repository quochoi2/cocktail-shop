using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private IProductBusiness _bus;
		public ProductController(IProductBusiness bus)
		{
			_bus = bus;
		}

		[HttpGet("get-all")]
		public IActionResult GetAllProduct()
		{
			var dt = _bus.GetAllProduct().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}

		[HttpGet("get-by-id")]
		public IActionResult GetByIdProduct(string id)
		{
			var dt = _bus.GetByIdProduct(id);
			return Ok(dt);
		}

		[HttpPost("create-product")]
		public ProductModel CreateProduct([FromBody] ProductModel model)
		{
			_bus.CreateProduct(model);
			return model;
		}

		[HttpPut("update-product")]
		public ProductModel UpdateProduct([FromBody] ProductModel model)
		{
			_bus.UpdateProduct(model);
			return model;
		}

		[HttpDelete("delete-product")]
		public IActionResult DeleteProduct(string model)
		{
			_bus.DeleteProduct(model);
			return Ok(new { message = "xoa thanh cong" });
		}

		[Route("search-product")]
		[HttpPost]
		public IActionResult Search([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var page = int.Parse(formData["page"].ToString());
				var pageSize = int.Parse(formData["pageSize"].ToString());
				string ten = "";
				if (formData.Keys.Contains("ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ten"])))
				{
					ten = Convert.ToString(formData["ten"]);
				}
				
				long total = 0;
				var data = _bus.SearchProduct(page, pageSize, ten, out total);
				return Ok(
					new
					{
						TotalItems = total,
						Page = page,
						PageSize = pageSize,
						Data = data
					}
					);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
