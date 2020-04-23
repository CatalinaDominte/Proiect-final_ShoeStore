using Project.BusinessLogic;
using Project.Data;
using ShoeControl.Filters;
using ShoeControl.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data;
using ShoeControl.App_Data;

namespace ShoeControl.Controllers.Products
{
    [Authorize]
  //  [SimpleFilter]
  // [CustomErrorHandler]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository products;
        private readonly IProductsCreateRepository prodCreate;
        readonly MyDBConnectionString DB = new MyDBConnectionString();
        readonly DataTable tbCategory = new DataTable();
        readonly DataTable tbStore = new DataTable();
        readonly DataTable tbSuppliers = new DataTable();

        public ProductsController()
        {
            this.products = new ProductsDetailedRepository(ConnectionManager.GetConnection());
            this.prodCreate = new ProductsForAdminRepository(ConnectionManager.GetConnection());
        }
        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        // GET: Products
        [HttpGet]
        public ActionResult Index(string searchBy, string search, int? page)
        {

            // entity from database
            List<ProductsForView> allproducts = this.products.GetAll();
            // model for view
            List<ProductsViewModel> list = new List<ProductsViewModel>();
            foreach (var product in allproducts)
            {
                list.Add(new ProductsViewModel
                {
                    Name = product.Name,
                    ProductId = product.Id,
                    Id = product.ModelId,
                    Suppliers = product.Suppliers,
                    Category = product.Category,
                    Store = product.StoreLocation,
                    Description = product.ProductsDescription,
                    Stock = product.UnitsInStock,
                    Discount = product.Discount,
                    Price = product.FinalPrice,
                    Size = product.Size,
                    Colour = product.Colour
                });

            }
            if(searchBy=="Name")
            {
                return View(list.Where(x=>x.Name.StartsWith(search) || search == null).ToPagedList(page ?? 1, 8));
            }
            else
            {
                return View(list.Where(x => x.Id == search || search == null).ToPagedList(page ?? 1, 8));
            }

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            // entity from database
            ProductsForAdmin allproducts = this.prodCreate.GetDetails(id);
            // model for view
            ProductsRowModel list = new ProductsRowModel()
            {
                ProductId = allproducts.Id,
                Name = allproducts.Name,
                Colour = allproducts.Colour,
                Suppliers = allproducts.SuppliersId,
                Category = allproducts.CategoryId,
                Store = allproducts.StoreLocationId,
                Size = allproducts.Size,
                EntryDate = allproducts.EntryDate,
                Description = allproducts.ProductsDescription,
                Stock = allproducts.UnitsInStock,
                Discount = allproducts.Discount,
                Price = allproducts.FinalPrice,
                UnitPrice = allproducts.UnitPrice
            };
           
            return View(list);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            tbCategory.Columns.Add("CategoryId", typeof(int));
            tbCategory.Columns.Add("Category", typeof(string));

            tbStore.Columns.Add("StoreId", typeof(int));
            tbStore.Columns.Add("Store", typeof(string));

            tbSuppliers.Columns.Add("SuplliersId", typeof(int));
            tbSuppliers.Columns.Add("Suplliers", typeof(string));

            List<App_Data.Category> lista = DB.Set<App_Data.Category>().ToList();
            foreach (App_Data.Category category in lista)
            {
                tbCategory.Rows.Add(category.CategoryId, category.CategoryName);
            }

            ViewBag.CategoryList = ToSelectList(tbCategory, "CategoryId", "Category");

            List<App_Data.StoreLocation> listaStore = DB.Set<App_Data.StoreLocation>().ToList();
            foreach (App_Data.StoreLocation store in listaStore)
            {
                tbStore.Rows.Add(store.StoreId, store.StoreName);
            }
            ViewBag.StoreList = ToSelectList(tbStore, "StoreId", "Store");

            List<Supplier> SupplierList = DB.Set<Supplier>().ToList();
            foreach (Supplier supplier in SupplierList)
            {
                tbSuppliers.Rows.Add(supplier.SuppliersId, supplier.SuppliersName);
            }
            ViewBag.SuppliersList = ToSelectList(tbSuppliers, "SuplliersId", "Suplliers");

            return View();
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Create(ProductsRowModel productRow)
        {
            ProductsForAdmin rowModel = new ProductsForAdmin()
            {
                ModelId= productRow.Id,
                Name= productRow.Name,
                SuppliersId= productRow.Suppliers,
                CategoryId= productRow.Category,
                StoreLocationId= productRow.Store,
                ProductsDescription= productRow.Description,
                UnitsInStock= productRow.Stock,
                UnitPrice= productRow.UnitPrice,
                Discount= productRow.Discount,
                FinalPrice= productRow.Price,
                Size= productRow.Size,
                Colour= productRow.Colour,
                EntryDate= productRow.EntryDate
            };

            prodCreate.Create(rowModel);


            ViewBag.Message = "Student Details Added Successfully";
            ModelState.Clear();
            return RedirectToAction("Create");
        }

       
        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (prodCreate.Delete(id) >= 1)
            {
                ViewBag.Mesage = "Product Deleted Successfully";
            }
            return RedirectToAction("Index");

        }
     
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Edit(int id)
        {
            tbCategory.Columns.Add("CategoryId", typeof(int));
            tbCategory.Columns.Add("Category", typeof(string));

            tbStore.Columns.Add("StoreId", typeof(int));
            tbStore.Columns.Add("Store", typeof(string));

            tbSuppliers.Columns.Add("SuplliersId", typeof(int));
            tbSuppliers.Columns.Add("Suplliers", typeof(string));

            List<App_Data.Category> lista = DB.Set<App_Data.Category>().ToList();
            foreach (App_Data.Category category in lista)
            {
                tbCategory.Rows.Add(category.CategoryId, category.CategoryName );
            }

            ViewBag.CategoryList = ToSelectList(tbCategory, "CategoryId", "Category");

            List<App_Data.StoreLocation> listaStore = DB.Set<App_Data.StoreLocation>().ToList();
            foreach (App_Data.StoreLocation store in listaStore)
            {
                tbStore.Rows.Add(store.StoreId, store.StoreName);
            }
            ViewBag.StoreList = ToSelectList(tbStore, "StoreId", "Store");

            List<Supplier> SupplierList = DB.Set<Supplier>().ToList();
            foreach (Supplier supplier in SupplierList)
            {
                tbSuppliers.Rows.Add(supplier.SuppliersId, supplier.SuppliersName);
            }
            ViewBag.SuppliersList = ToSelectList(tbSuppliers, "SuplliersId", "Suplliers");
            return View(prodCreate.GetAll().Find(x => x.Id == id));
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Edit(ProductsForAdmin rowModel, int id)
        {

           /* ProductsForAdmin rowModel = new ProductsForAdmin()
            {
                ModelId = productRow.Id,
                ProductsName = productRow.Name,
                SuppliersId = productRow.Suppliers,
                CategoryId = productRow.Category,
                StoreLocationId = productRow.Store,
                ProductsDescription = productRow.Description,
                UnitsInStock = productRow.Stock,
                UnitPrice = productRow.UnitPrice,
                Discount = productRow.Discount,
                FinalPrice = productRow.Price,
                Size = productRow.Size,
                Colour = productRow.Colour,
                EntryDate = productRow.EntryDate
            };*/
            if (prodCreate.Update(rowModel, id) >= 1)
            {
                ViewBag.Message = "Student Details Updated Successfully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
           

            return View();
            

        }
    }
}