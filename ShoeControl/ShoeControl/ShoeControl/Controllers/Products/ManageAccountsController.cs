using Project.BusinessLogic;
using Project.Data;
using ShoeControl.App_Data;
using ShoeControl.Filters;
using ShoeControl.Models;
using ShoeControl.Models.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeControl.Controllers.Products
{
    [Authorize]
  // [SimpleFilter]
 // [CustomErrorHandler]
    public class ManageAccountsController : Controller
    {
        private readonly IManageAccountsRepository account;
        readonly MyDBConnectionString DB = new MyDBConnectionString();
        readonly DataTable tb = new DataTable();
        public ManageAccountsController()
        {
            this.account = new ManageAccountsRepository(ConnectionManager.GetConnection());

        }
        // GET: Products
        [HttpGet]
        [Authorize(Roles = "1")]
        public ActionResult Index()
        {

            // entity from database
            List<ManageAccounts> allAccounts = this.account.GetAll();
            // model for view
            List<ManageAcountsViewModel> list = new List<ManageAcountsViewModel>();
            foreach (var account in allAccounts)
            {
                list.Add(new ManageAcountsViewModel
                {
                    Id = account.Id,
                    Username = account.Name,
                    Password = account.Password,
                    Role_id=account.Role_id


                });
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            tb.Columns.Add("role_id", typeof(int));
            tb.Columns.Add("role", typeof(string));

           
            List<Role> lista = DB.Set<Role>().ToList();

            foreach (Role role in lista)
            {
                tb.Rows.Add(role.role_id, role.role1 + " (" + role.Notes + ")");
            }

            ViewBag.RolesList = ToSelectList(tb, "role_id", "role");
            return View();
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Create(ManageAcountsViewModel accountView)
        {
            ManageAccounts accounts = new ManageAccounts()
            {
                Name = accountView.Username,
                Password = accountView.Password,
                Role_id = accountView.Role_id

            };

            account.Create(accounts);


            ViewBag.Message = "Account Details Added Successfully";
            ModelState.Clear();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (account.Delete(id) >= 1)
            {
                ViewBag.Mesage = "Account Deleted Successfully";
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           
            //test pt Entity
           
            tb.Columns.Add("role_id", typeof(int));
            tb.Columns.Add("role", typeof(string));
           
           
            List<Role> lista = DB.Set<Role>().ToList();

            foreach (Role role in lista)
            {
                tb.Rows.Add(role.role_id,role.role1 + " (" +role.Notes+")");
            }

            ViewBag.RolesList = ToSelectList(tb, "role_id", "role");

            return View(account.GetAll().Find(x => x.Id == id));
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

        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult Edit(ManageAccounts accounts, int id)
        {

            if (account.Update(accounts, id) >= 1)
            {
                ViewBag.Message = "Account Details Updated Successfully";
                ModelState.Clear();
                return RedirectToAction("Index");
            }


            return View();


        }
    }
}