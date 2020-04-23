using Project.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data
{
    public class ProductsDetailedRepository: IProductsRepository
    {
        private readonly SqlConnection connection2;
        
        public ProductsDetailedRepository(SqlConnection connection)
        {
            this.connection2 =  connection;
           
        }
        public List<ProductsForView> GetAll()
        {

            List<ProductsForView> Products = new List<ProductsForView>();
            

            SqlCommand command = new SqlCommand("GetAllProducts", connection2);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    ProductsForView products = new ProductsForView(); 
                    products.Id = (int)currentRow["ProductsId"];
                    products.ModelId = currentRow["ModelId"].ToString();
                    products.Name = currentRow["ProductsName"].ToString();
                    products.Suppliers = currentRow["Supplier"].ToString();
                    products.Category = currentRow["Category"].ToString();
                    products.StoreLocation = currentRow["StoreLocation"].ToString();
                    products.ProductsDescription = currentRow["ProductsDescription"].ToString();
                    products.UnitsInStock = (int)currentRow["UnitsInStock"];
                    products.Discount = (decimal)currentRow["Discount"];
                    products.FinalPrice = (decimal)currentRow["FinalPrice"];
                    products.Size = currentRow["Size"].ToString();
                    products.Colour = currentRow["AvaibleColours"].ToString();
                    
                    Products.Add(products);
                }
                
            }
           
            return Products;
            
        }
       
       
    }
    }



