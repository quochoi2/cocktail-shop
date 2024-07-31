using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BillDetailsController : Controller
	{
		private IBillDetailsBusiness _bus;
		public BillDetailsController(IBillDetailsBusiness bus)
		{
			_bus = bus;
		}

		[Route("get-by-id/{id}")]
		[HttpGet]
		public BillDetail GetAllByIdBill(int id)
		{
			return _bus.GetAllByIdBill(id);
		}

		[HttpDelete("delete-bill-detail")]
		public IActionResult DeleteProduct(string model)
		{
			_bus.DeleteBillDetail(model);
			return Ok(new { message = "xoa thanh cong" });
		}
	}
}
