using CoreAndFood.DATA.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    [Authorize(Roles ="A")]
    public class CategoryController : Controller
    {
        CategoryRepositories categoryRepositories = new CategoryRepositories();
        public IActionResult Index()
        {       
            return View(categoryRepositories.TList());
        }


        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }

            categoryRepositories.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepositories.TGet(id);
            return View(x);     
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x = categoryRepositories.TGet(p.CategoryID);

            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;

            x.Status = true;

            categoryRepositories.TUpdate(x);

            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var x = categoryRepositories.TGet(id);
            x.Status = false;

            categoryRepositories.TUpdate(x);
             
            return RedirectToAction("Index");
        }



    }
}
