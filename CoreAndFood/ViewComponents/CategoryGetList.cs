using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class CategoryGetList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryRepositories categoryRepositories = new CategoryRepositories();
			var categorylist = categoryRepositories.TList();
			return View(categorylist);
		}
	}
}
