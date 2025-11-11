using System.Data.SqlClient;

namespace Databases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //connects to database
            SqlConnectionStringBuilder conBldr = new SqlConnectionStringBuilder();
            conBldr["server"] = @"(localdb)\MSSQLLocalDB";
            conBldr["Trusted_Connection"] = true;
            conBldr["Integrated Security"] = "SSPI";
            conBldr["Initial Catalog"] = "PROG260FA23";
            string conStr = conBldr.ToString();

            //populates table
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string redApples = @"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) VALUES ('Red Apples', '12F', 2.99, 'Bag', '10-31-2023')";
                string bananas = @"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) VALUES ('Bananas', '9A', .29, 'Ea', '10-15-2023')";
                string greenApples = @"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) VALUES ('Green Apples', '13F', 3.15, 'Lbs', '9-09-2024')";
                string watermelon = @"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) VALUES ('Watermelon', '6B', 6.99, 'Each', '12-15-2023')";
                string yellowApples = @"INSERT [dbo].[Produce] ([Name], [Location], [Price], [UoM], [Sell_by_Date]) VALUES ('Yellow Apples', '12A', 4.19, 'Bag', '10-29-2023')";
            
                using (var command = new SqlCommand(redApples, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(bananas, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(greenApples, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(watermelon, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(yellowApples, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //changes produce location from -F to -Z
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string update12F = @"UPDATE [dbo].[Produce] SET Location = '12Z' WHERE Location = '12F'";
                string update13F = @"UPDATE [dbo].[Produce] SET Location = '13Z' WHERE Location = '13F'";
                using (var command = new SqlCommand(update12F, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                using (var command = new SqlCommand(update13F, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //Deletes expired produce
            //GETDATE() method from https://www.w3schools.com/sql/func_sqlserver_getdate.asp
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string deleteExpired = @"DELETE FROM [dbo].[Produce] WHERE Sell_by_Date < GETDATE()";
                using (var command = new SqlCommand(deleteExpired, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //increases price by $1
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string increasePrice = @"UPDATE [dbo].[Produce] SET Price = Price + 1 WHERE ID > 0";
                using (var command = new SqlCommand(increasePrice, connection))
                {
                    var query = command.ExecuteNonQuery();
                }
                connection.Close();
            }

            //outputs table to file
            StreamWriter writer = new StreamWriter("..\\..\\..\\files\\Produce_out.txt");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string inlineSQL = @"Select * from Produce";
                using (var command = new SqlCommand(inlineSQL, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)}, {reader.GetValue(1)}, {reader.GetValue(2)}, {reader.GetValue(3)}, {reader.GetValue(4)}";

                        writer.WriteLine(value);
                    }
                    reader.Close();
                }
                connection.Close();
            }
            writer.Close();

        }
    }
}