using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.Data;
using ST10079389_Kaushil_Dajee_PROG7311.Models;

namespace ST10079389_Kaushil_Dajee_PROG7311
{
    public class Encrypt
    {
        public string Hash_Password(string input)
        {//used this to hash my password all my passwords are hashed to protect the users information
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);
                //same method used to hash passwords for safety
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public int GetID(string username, string password)
        {//i have to pass userID everywhere so that only the one user can see their own information no one elses
            string sqlConnection = "Data Source=.;Initial Catalog=AgriEnergyWebsiteDB;Integrated Security=True;Encrypt=False";
            int userID;
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                string query = "SELECT UserID FROM Users WHERE Name = @Name AND Password = @Password";//query used to get the users id
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", username);
                    command.Parameters.AddWithValue("@Password", password);//parameters to check it
                    userID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return userID;//this is used so when any user enters their information for a module, a notification or a study session the user id is saved to basically ensure its for only that user
        }
        //private List<Category> InitializeCategoryBox()
        //{
        //    List<Category> category = new List<Category>();
        //    string sqlConnection = "Data Source=.;Initial Catalog=AgriEnergyWebsiteDB;Integrated Security=True;Encrypt=False"; 
        //    SqlConnection con = new SqlConnection(sqlConnection);
        //    con.Open();
        //    string query = "SELECT * FROM Category";//query used to get the modules name then displays on the combo box
        //    SqlCommand command = new SqlCommand(query, con);
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            string CategoryName = reader["CategoryName"].ToString();//finds all the modules so the user can select the module instead of typing it with ease
        //            int CategoryID = Convert.ToInt32(reader["CategoryID"]);
        //            category.Add(reader);
        //        }
        //    }
        //    reader.Close();
        //    con.Close();
        //    return category;
        //}

    }
}
