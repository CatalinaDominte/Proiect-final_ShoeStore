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
    
    public class ProductsForAdminRepository : IProductsCreateRepository
    {
        private readonly SqlConnection connection2;

        public ProductsForAdminRepository(SqlConnection connection)
        {
            this.connection2 = connection;

        }
        public List<ProductsForAdmin> GetAll()
        {
            List<ProductsForAdmin> Products = new List<ProductsForAdmin>();

            SqlCommand command = new SqlCommand("GetAll", connection2);
            command.CommandType = CommandType.StoredProcedure;
           
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    ProductsForAdmin products = new ProductsForAdmin();
                    products.Id = (int)currentRow["ProductsId"];
                    products.ModelId = currentRow["ModelId"].ToString();
                    products.Name = currentRow["ProductsName"].ToString();
                    products.SuppliersId = (int)currentRow["Suppliers"];
                    products.CategoryId = (int)currentRow["Category"];
                    products.StoreLocationId = (int)currentRow["StoreLocation"];
                    products.Size = currentRow["Size"].ToString();
                    products.EntryDate = (DateTime)currentRow["EntryDate"];
                    products.ProductsDescription = currentRow["ProductsDescription"].ToString();
                    products.UnitsInStock = (int)currentRow["UnitsInStock"];
                    products.Discount = (decimal)currentRow["Discount"];
                    products.FinalPrice = (decimal)currentRow["FinalPrice"];
                    products.UnitPrice = (decimal)currentRow["UnitPrice"];
                    products.Colour = currentRow["AvaibleColours"].ToString();
                    Products.Add(products);
                }
            }

            return 
                Products;

        }
        public ProductsForAdmin GetDetails(int id)
        {
            ProductsForAdmin products = new ProductsForAdmin();


            SqlCommand command = new SqlCommand("GetDetails", connection2);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    
                    products.Id = (int)currentRow["ProductsId"];
                    products.ModelId = currentRow["ModelId"].ToString();
                    products.Name = currentRow["ProductsName"].ToString();
                    products.SuppliersId = (int)currentRow["Suppliers"];
                    products.CategoryId = (int)currentRow["Category"];
                    products.StoreLocationId = (int)currentRow["StoreLocation"];
                    products.Size = currentRow["Size"].ToString();
                    products.EntryDate = (DateTime)currentRow["EntryDate"];
                    products.ProductsDescription = currentRow["ProductsDescription"].ToString();
                    products.UnitsInStock = (int)currentRow["UnitsInStock"];
                    products.Discount = (decimal)currentRow["Discount"];
                    products.FinalPrice = (decimal)currentRow["FinalPrice"];
                    products.UnitPrice = (decimal)currentRow["UnitPrice"];
                    products.Colour = currentRow["AvaibleColours"].ToString();

                    
                }
              
            }

            return products;

        }

        public int Create(ProductsForAdmin products)
        {

            SqlCommand cmd = new SqlCommand("CreateProducts", connection2);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@1", products.ModelId);
                cmd.Parameters.AddWithValue("@2", products.Name);
                cmd.Parameters.AddWithValue("@3", products.SuppliersId);
                cmd.Parameters.AddWithValue("@4", products.CategoryId);
                cmd.Parameters.AddWithValue("@5", products.StoreLocationId);
                cmd.Parameters.AddWithValue("@6", products.ProductsDescription);
                cmd.Parameters.AddWithValue("@7", products.UnitsInStock);
                cmd.Parameters.AddWithValue("@8", products.UnitPrice);
                cmd.Parameters.AddWithValue("@9", products.Discount);
                cmd.Parameters.AddWithValue("@10", products.FinalPrice);
                cmd.Parameters.AddWithValue("@11", products.Size);
                cmd.Parameters.AddWithValue("@12", products.Colour);
                cmd.Parameters.AddWithValue("@13", products.EntryDate);

                int i = cmd.ExecuteNonQuery();

                return i;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public int Delete(int id)
        {
           
            SqlCommand cmd = new SqlCommand("DeleteProduct", connection2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        
        public int Update(ProductsForAdmin products, int id)
        {
          
                        
            SqlCommand cmd = new SqlCommand("UpdateProducts", connection2);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@1", products.ModelId);
            cmd.Parameters.AddWithValue("@2", products.Name);
            cmd.Parameters.AddWithValue("@3", products.SuppliersId);
            cmd.Parameters.AddWithValue("@4", products.CategoryId);
            cmd.Parameters.AddWithValue("@5", products.StoreLocationId);
            cmd.Parameters.AddWithValue("@6", products.ProductsDescription);
            cmd.Parameters.AddWithValue("@7", products.UnitsInStock);
            cmd.Parameters.AddWithValue("@8", products.UnitPrice);
            cmd.Parameters.AddWithValue("@9", products.Discount);
            cmd.Parameters.AddWithValue("@10", products.FinalPrice);
            cmd.Parameters.AddWithValue("@11", products.Size);
            cmd.Parameters.AddWithValue("@12", products.Colour);
            cmd.Parameters.AddWithValue("@13", products.EntryDate);
            cmd.Parameters.AddWithValue("@Id", id);

            int i = cmd.ExecuteNonQuery();
            
                return i;
           
        }
}
}

    

