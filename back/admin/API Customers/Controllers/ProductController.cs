using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API_Customers.Controllers
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
			var dt = _bus.GetAllProduct().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh });
			return Ok(dt);
		}

		[HttpGet("get-by-id")]
		public IActionResult GetByIdProduct(string id)
		{
			var dt = _bus.GetByIdProduct(id);
			return Ok(dt);
		}
	}
}
