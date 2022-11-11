using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepositories foodRepository = new FoodRepositories();
            var foodlist = foodRepository.TList();
            return View(foodlist);
        }
    }
}
