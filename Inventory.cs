using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleInventoryManagementSystem
{
    /// <summary>
    /// Inventory class to save a list of products, and implement the methods applied on that list.
    /// </summary>
    public static class Inventory
    {
        public static List<Product> products = new List<Product>();
        static string connectionString = "Server=DESKTOP-P1OAHG7\\MSSQLSERVER06;Database=SIMS;Integrated Security=True;";
        public static SqlConnection connection = new SqlConnection(connectionString);
        public static List<string> Search(string value)
        {
            StringBuilder foundData = new StringBuilder();
            string searchQuery = $"select * from Products where productName = '{value}'";
            List<string> foundProducts = new List<string>();
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            SqlCommand command = new SqlCommand(searchQuery, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                foundData.Append(reader["productName"].ToString() + " ");
                foundData.Append(reader["price"].ToString() + " ");
                foundData.AppendLine(reader["quantity"].ToString());
                foundProducts.Add(foundData.ToString());
            }
            connection.Close();
            return foundProducts;
        }

        public static string Add(Product product)
        {
            const string success = "Product added successfully";
            const string failed = "add failed: Product may already exist";
            string insertQuery = $"insert into Products (productName, price, quantity) values ('{product.name}',{product.price},{product.quantity}) ";
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
               return "Error: " + ex.Message;
            }

            try
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return success;
            }
            catch (Exception ex)
            {
                connection.Close();
                return failed;
            }
            
            
        }

        public static string ViewAll()
        {
            string failed = "Products list is empty.";
            string query = "select * from Products";
            StringBuilder data = new StringBuilder();
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Append(reader["productName"].ToString() + " ");
                data.Append(reader["price"].ToString() + " ");
                data.AppendLine(reader["quantity"].ToString());

            }
            connection.Close();
            if (data.ToString() != "")
                return data.ToString();
            else return failed;
        }

        public static string Edit(string name, string newName, double newPrice, int newQuantity)
        {
            //response messages.
            const string success = "Edit was successful";
            const string failed = "Edit failed: product may not exist";
            const string nameExists = "Edit failed: product name already exist";

            Product product = new Product();

            string updateQuery = $"update Products set productName = '{newName}', price = {newPrice}, quantity = {newQuantity} where productName = '{name}'";

            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            try
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return success;
            }
            catch (Exception ex)
            {
                connection.Close();
                return failed;
            }
        }

        public static string Delete(string name)
        {
            ////response messages.
            const string success = "Product deleted successfully";
            const string failed = "delete failed: product may not exist";

            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }

            try
            {
                string deleteQuery = $"delete from Products where productName = '{name}'";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return success; 
            }
            catch (Exception ex)
            {
                connection.Close();
                return failed;
            }
            


        }

    }
}
