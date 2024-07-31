using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ReceiptController : ControllerBase
	{
		private IReceiptBusiness _bus;
		public ReceiptController(IReceiptBusiness bus)
		{
			_bus = bus;
		}

		//[HttpGet("get-all")]
		//public IActionResult GetAllReceipt()
		//{
		//	var dt = _bus.GetAllReceipt().Select(x => new { x.hdnId, x.nId, x.hdnNgayLap });
		//	return Ok(dt);
		//}

		[Route("get-by-id-receipt/{id}")]
		[HttpGet]
		public ReceiptModel GetDatabyIDReceipt(int id)
		{
			return _bus.GetDatabyIDReceipt(id);
		}

		[Route("create-receipt")]
		[HttpPost]
		public ReceiptModel CreateReceipt([FromBody] ReceiptModel model)
		{
			_bus.CreateReceipt(model);
			return model;
		}

		[Route("update-receipt")]
		[HttpPost]
		public ReceiptModel UpdateReceipt([FromBody] ReceiptModel model)
		{
			_bus.UpdateReceipt(model);
			return model;
		}
	}
}
