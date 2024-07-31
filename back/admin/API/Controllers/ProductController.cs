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

		[HttpGet("get-all-filter-increase")]
		public IActionResult FilterIncrease()
		{
			var dt = _bus.FilterIncrease().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}

		[HttpGet("get-all-filter-decrease")]
		public IActionResult FilterDecrease()
		{
			var dt = _bus.FilterDecrease().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}

		[HttpGet("get-all-filter-low")]
		public IActionResult FilterLow()
		{
			var dt = _bus.FilterLow().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}

		[HttpGet("get-all-filter-medium")]
		public IActionResult FilterMedium()
		{
			var dt = _bus.FilterMedium().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}

		[HttpGet("get-all-filter-high")]
		public IActionResult FilterHigh()
		{
			var dt = _bus.FilterHigh().Select(x => new { x.spId, x.sTen, x.sGia, x.sAnh, x.sSoLuong });
			return Ok(dt);
		}
	}
}
