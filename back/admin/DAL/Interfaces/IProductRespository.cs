using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IProductRespository
	{
		List<ProductModel> GetAllProduct();
		ProductModel GetByIdProduct(string id);
		bool CreateProduct(ProductModel model);
		bool UpdateProduct(ProductModel model);
		bool DeleteProduct(string id);
		List<ProductModel> SearchProduct(int pageIndex, int pageSize, string ten, out long total);
	}
}
