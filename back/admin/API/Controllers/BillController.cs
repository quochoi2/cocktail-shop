using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class BillController : ControllerBase
	{
		private IBillBusiness _bus;
		public BillController(IBillBusiness bus)
		{
			_bus = bus;
		}

		[Route("get-by-id/{id}")]
		[HttpGet]
		public BillModel GetDatabyIDbill(int id)
		{
			return _bus.GetDatabyIDBill(id);
		}

		[Route("create-bill")]
		[HttpPost]
		public BillModel CreateBill([FromBody] BillModel model)
		{
			_bus.CreateBill(model);
			return model;
		}
	}
}
