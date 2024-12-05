using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApp1.Data_Access
{
    internal class DatabaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        public DataTable GetProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Items", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                return dt;
            }
        }
        public void AddProduct(string name, decimal price, bool inStock, string imagePath, DateTime addedDate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            { SqlCommand cmd = new SqlCommand("INSERT INTO Items (ProductName, Price, InStock, ImagePath, AddedDate) VALUES (@Name, @Price, @InStock, @ImagePath, @AddedDate)", conn);
                cmd.Parameters.AddWithValue("@Name", name); 
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@InStock", inStock);
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                cmd.Parameters.AddWithValue("@AddedDate", addedDate);
                conn.Open(); cmd.ExecuteNonQuery(); } }
        public void UpdateProduct(int id, string name, decimal price, bool inStock, string imagePath, DateTime addedDate) { using (SqlConnection conn = new SqlConnection(connectionString)) { SqlCommand cmd = new SqlCommand("UPDATE Items SET ProductName = @Name, Price = @Price, InStock = @InStock, ImagePath = @ImagePath, AddedDate = @AddedDate WHERE Id = @Id", conn); cmd.Parameters.AddWithValue("@Id", id); cmd.Parameters.AddWithValue("@Name", name); cmd.Parameters.AddWithValue("@Price", price); cmd.Parameters.AddWithValue("@InStock", inStock); cmd.Parameters.AddWithValue("@ImagePath", imagePath); cmd.Parameters.AddWithValue("@AddedDate", addedDate); conn.Open(); cmd.ExecuteNonQuery(); } }
        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString)) { SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE Id = @Id", conn); cmd.Parameters.AddWithValue("@Id", id); conn.Open(); cmd.ExecuteNonQuery(); }
        }
    }
}
