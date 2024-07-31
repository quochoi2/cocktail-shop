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

		public List<ProductModel> FilterIncrease()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_san_pham_tang_dan");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public List<ProductModel> FilterDecrease()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_san_pham_giam_dan");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public List<ProductModel> FilterLow()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_san_pham_gia_thap");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public List<ProductModel> FilterMedium()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_san_pham_gia_trung_binh");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public List<ProductModel> FilterHigh()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_san_pham_gia_cao");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ProductModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
