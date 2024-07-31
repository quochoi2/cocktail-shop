using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IProductBusiness
	{
		List<ProductModel> GetAllProduct();
		ProductModel GetByIdProduct(string id);
		List<ProductModel> FilterIncrease();
		List<ProductModel> FilterDecrease();
		List<ProductModel> FilterLow();
		List<ProductModel> FilterMedium();
		List<ProductModel> FilterHigh();
	}
}
