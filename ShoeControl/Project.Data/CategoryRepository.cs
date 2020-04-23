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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlConnection connection;

        public CategoryRepository(SqlConnection connection)
        {
            this.connection = connection;

        }
        public List<Category> GetAll()
        {
            List<Category> Category = new List<Category>();

            SqlCommand command = new SqlCommand("GetAllCategory", connection);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    Category category = new Category();
                    category.Id = (int)currentRow["CategoryId"];
                    category.Name = currentRow["CategoryName"].ToString();
                    category.CategoryDescription = currentRow["CategoryDescription"].ToString();

                    Category.Add(category);
                }
            }
            return
                Category;
        }
        public Category GetDetails(int id)
        {
            Category category = new Category();

            SqlCommand command = new SqlCommand("GetDetailsCategory", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var currentRow = dataReader;
                    category.Id = (int)currentRow["CategoryId"];
                    category.Name = currentRow["CategoryName"].ToString();
                    category.CategoryDescription = currentRow["CategoryDescription"].ToString();
                }
                return category;
            }
        }
        public int Create(Category category)
        {


            SqlCommand cmd = new SqlCommand("CreateCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@1", category.Name);
                cmd.Parameters.AddWithValue("@2", category.CategoryDescription);

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
            
            SqlCommand cmd = new SqlCommand("DeleteCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            return i;
        }

        public int Update(Category category, int id)
        {

            SqlCommand cmd = new SqlCommand("UpdateCategory", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@1", category.Name);
            cmd.Parameters.AddWithValue("@2", category.CategoryDescription);

            cmd.Parameters.AddWithValue("@Id", id);

            int i = cmd.ExecuteNonQuery();

            return i;

        }
    }
}
