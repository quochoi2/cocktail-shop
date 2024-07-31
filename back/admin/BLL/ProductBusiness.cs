using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class ProductBusiness : IProductBusiness
	{
		private IProductRespository _res;
		public ProductBusiness(IProductRespository res)
		{
			_res = res;
		}

		public List<ProductModel> GetAllProduct()
		{
			return _res.GetAllProduct();
		}
		public ProductModel GetByIdProduct(string id)
		{
			return _res.GetByIdProduct(id);
		}

		public List<ProductModel> FilterIncrease()
		{
			return _res.FilterIncrease();
		}
		public List<ProductModel> FilterDecrease()
		{
			return _res.FilterDecrease();
		}
		public List<ProductModel> FilterLow()
		{
			return _res.FilterLow();
		}
		public List<ProductModel> FilterMedium()
		{
			return _res.FilterMedium();
		}
		public List<ProductModel> FilterHigh()
		{
			return _res.FilterHigh();
		}
	}
}
