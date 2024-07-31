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
		public bool CreateProduct(ProductModel model)
		{
			return _res.CreateProduct(model);
		}
		public bool UpdateProduct(ProductModel model)
		{
			return _res.UpdateProduct(model);
		}
		public bool DeleteProduct(string id)
		{
			return _res.DeleteProduct(id);
		}
		public List<ProductModel> SearchProduct(int pageIndex, int pageSize, string ten, out long total)
		{
			return _res.SearchProduct(pageIndex, pageSize, ten, out total);
		}
	}
}
