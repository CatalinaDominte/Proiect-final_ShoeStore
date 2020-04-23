using Project.BusinessLogic;
using Project.Data;
using ShoeControl.Filters;
using ShoeControl.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeControl.Controllers.Products
{
    [Authorize]
   // [SimpleFilter]
  //  [CustomErrorHandler]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository category;
       
        
        public CategoryController()
        {
            this.category = new CategoryRepository(ConnectionManager.GetConnection());
            
        }
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {

            // entity from database
            List<Category> allCategory = this.category.GetAll();
            // model for view
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            foreach (var category in allCategory)
            {
                list.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    CategoryDescription = category.CategoryDescription,
                    
                });
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryView)
        {
            Category categoryBase = new Category()
            {
                Id = categoryView.Id,
                Name = categoryView.Name,
                CategoryDescription = categoryView.CategoryDescription,

            };

            category.Create(categoryBase);


            ViewBag.Message = "Category Details Added Successfully";
            ModelState.Clear();
            return View();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (category.Delete(id) >= 1)
            {
                ViewBag.Mesage = "Category Deleted Successfully";
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(int id)
        {
           
            return View(category.GetAll().Find(x => x.Id == id));
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Edit(Category categoryBase, int id)
        {

            if (category.Update(categoryBase, id) >= 1)
            {
                ViewBag.Message = "Category Details Updated Successfully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }


            return View();


        }

    }
}