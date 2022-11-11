using CoreAndFood.DATA.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepositories foodRepositories = new FoodRepositories();

        Context c = new Context();
        public IActionResult Index(int page=1)
        {           
            return View(foodRepositories.TList("Category").ToPagedList(page,3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;

            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food p)
        {
            foodRepositories.TAdd(p);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteFood(int id)
        {
            foodRepositories.TDelete(new Food { FoodID=id });
            return RedirectToAction("Index");
        }

        public IActionResult FoodGet(int id)
        {
            var x = foodRepositories.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View(x);
        }

        [HttpPost]
        public IActionResult FoodUptade(Food p)
        {
            var x = foodRepositories.TGet(p.FoodID);

            x.Name = p.Name;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL=p.ImageURL;
            x.Description = p.Description;
            x.CategoryID = p.CategoryID;

            foodRepositories.TUpdate(x);

            return RedirectToAction("Index");

        }
    }
}
