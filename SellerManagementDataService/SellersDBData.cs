using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SellerManagementModels;

namespace SellerManagementDataService
{
    public class SellersDBData : ISellerDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SellerMngmt;Integrated Security=True;TrustServerCertificate=True;";
        private SqlConnection sqlConnection;

        public SellersDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Added(SellerModels seller)
        {
            var query = @"INSERT INTO Sellers 
            VALUES (@SellerName,@Birthday,@EmailAddress,@PhoneNumber,@PresentAddress,@Username,@Bio)";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@SellerName", seller.SellerName);
            cmd.Parameters.AddWithValue("@Birthday", seller.Birthday);
            cmd.Parameters.AddWithValue("@EmailAddress", seller.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", seller.PhoneNumber);
            cmd.Parameters.AddWithValue("@PresentAddress", seller.PresentAddress);
            cmd.Parameters.AddWithValue("@Username", seller.Username);
            cmd.Parameters.AddWithValue("@Bio", seller.Bio);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<SellerModels> GetAccounts()
        {
            var list = new List<SellerModels>();

            string query = "SELECT * FROM Sellers";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SellerModels
                {
                    SellerName = reader["SellerName"].ToString(),
                    Birthday = reader["Birthday"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    PresentAddress = reader["PresentAddress"].ToString(),
                    Username = reader["Username"].ToString(),
                    Bio = reader["Bio"].ToString()
                });
            }

            sqlConnection.Close();
            return list;
        }

        public List<SellerModels> ViewAccounts()
        {
            var list = new List<SellerModels>();

            string query = "SELECT * FROM Sellers";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SellerModels
                {
                    SellerName = reader["SellerName"].ToString(),
                    Birthday = reader["Birthday"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    PresentAddress = reader["PresentAddress"].ToString(),
                    Username = reader["Username"].ToString(),
                    Bio = reader["Bio"].ToString()
                });
            }

            sqlConnection.Close();
            return list;
        }
        public SellerModels? Search(string username)
        {
            var query = "SELECT * FROM Sellers WHERE Username=@Username";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Username", username);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            SellerModels? seller = null;
            while (reader.Read())
            {
                seller = new SellerModels
                {
                    SellerName = reader["SellerName"].ToString(),
                    Birthday = reader["Birthday"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    PresentAddress = reader["PresentAddress"].ToString(),
                    Username = reader["Username"].ToString(),
                    Bio = reader["Bio"].ToString()
                };
            }
            sqlConnection.Close();
            return seller;
        }

        public void Update(SellerModels seller)
        {
            var query = @"UPDATE Sellers SET 
            SellerName=@SellerName,
            Birthday=@Birthday,
            EmailAddress=@EmailAddress,
            PhoneNumber=@PhoneNumber,
            PresentAddress=@PresentAddress,
            Bio=@Bio
            WHERE Username=@Username";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@SellerName", seller.SellerName);
            cmd.Parameters.AddWithValue("@Birthday", seller.Birthday);
            cmd.Parameters.AddWithValue("@EmailAddress", seller.EmailAddress);
            cmd.Parameters.AddWithValue("@PhoneNumber", seller.PhoneNumber);
            cmd.Parameters.AddWithValue("@PresentAddress", seller.PresentAddress);
            cmd.Parameters.AddWithValue("@Bio", seller.Bio);
            cmd.Parameters.AddWithValue("@Username", seller.Username);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string username)
        {
            var query = "DELETE FROM Sellers WHERE Username=@Username";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Username", username);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}