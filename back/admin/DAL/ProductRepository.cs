using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ProductRepository : IProductRespository
	{
		private IDatabaseHelper _db;
		public ProductRepository(IDatabaseHelper db)
		{
			_db = db;
		}
		public List<ProductModel> GetAllProduct()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_hien_thi_san_pham");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public ProductModel GetByIdProduct(string id)
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteSProcedureReturnDataTable(
					out msgError,
					"sp_tim_kiem_san_pham",
					"@spId",
					id);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().FirstOrDefault();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public bool CreateProduct(ProductModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_them_san_pham",
				"@sTen", model.sTen,
				"@sGia", model.sGia,
				"@sAnh", model.sAnh,
				"@sSoLuong", model.sSoLuong);


				if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
				{
					throw new Exception(Convert.ToString(result) + msgError);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool UpdateProduct(ProductModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_sua_san_pham",
				"@spId", model.spId,
				"@sTen", model.sTen,
				"@sGia", model.sGia,
				"@sAnh", model.sAnh,
				"@sSoLuong", model.sSoLuong);
				if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
				{
					throw new Exception(Convert.ToString(result) + msgError);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool DeleteProduct(string id)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_san_pham",
				"@spId", id);
				;
				if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
				{
					throw new Exception(Convert.ToString(result) + msgError);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<ProductModel> SearchProduct(int pageIndex, int pageSize, string ten, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_san_pham",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten", ten);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
