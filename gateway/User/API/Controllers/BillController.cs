using BLL.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BillController : ControllerBase
	{
		private IBillBusiness _bus;
		public BillController(IBillBusiness bus)
		{
			_bus = bus;
		}

		[HttpGet("get-all")]
		public IActionResult GetAllBill()
		{
			var dt = _bus.GetAllBill().Select(x => new { x.hdbId, x.kId, x.hdbNgayLap, x.hdbMoTa });
			return Ok(dt);
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

		[Route("update-bill")]
		[HttpPut]
		public BillModel UpdateBiill([FromBody] BillModel model)
		{
			_bus.UpdateBill(model);
			return model;
		}

		[Route("check-bill")]
		[HttpPut]
		public BillModel CheckBiill([FromBody] BillModel model)
		{
			_bus.CheckBill(model);
			return model;
		}

		[Route("search-bill")]
		[HttpPost]
		public IActionResult SearchBill([FromBody] Dictionary<string, object> formData)
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
				var data = _bus.SearchBill(page, pageSize, ten, out total);
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

		[Route("Statistics-user-by-bill")]
		[HttpPost]
		public IActionResult Search([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var page = int.Parse(formData["page"].ToString());
				var pageSize = int.Parse(formData["pageSize"].ToString());
				string ten_khach = "";
				if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
				DateTime? fr_NgayTao = null;
				if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
				{
					var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
					fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				}
				DateTime? to_NgayTao = null;
				if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
				{
					var dt = Convert.ToDateTime(formData["to_NgayTao"].ToString());
					to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
				}
				long total = 0;
				var data = _bus.StatisticsUser(page, pageSize, out total, ten_khach, fr_NgayTao, to_NgayTao);
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
		[Route("search-by-month")]
		[HttpPost]
		public IActionResult SearchByMonth([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var month = int.Parse(formData["month"].ToString());

				long total = 0;
				var data = _bus.SearchByMonth(month, out total);
				return Ok(
					new
					{
						TotalItems = total,
					}
					);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		[Route("search-bill-by-month")]
		[HttpPost]
		public IActionResult SearchBillByMonth([FromBody] Dictionary<string, object> formData)
		{
			try
			{
				var page = int.Parse(formData["page"].ToString());
				var pageSize = int.Parse(formData["pageSize"].ToString());

				DateTime? fr_NgayTao = null;
				if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
				{
					var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
					fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
				}
				DateTime? to_NgayTao = null;
				if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
				{
					var dt = Convert.ToDateTime(formData["to_NgayTao"].ToString());
					to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
				}
				long total = 0;
				var data = _bus.SearchBillByMonth(page, pageSize, fr_NgayTao, to_NgayTao, out total);
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
