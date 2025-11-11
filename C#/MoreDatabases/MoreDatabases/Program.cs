using System.Data.SqlClient;

namespace MoreDatabases
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHandler handler = new DatabaseHandler();
            handler.Run();
            List<string> characterData = handler.charData;
            List<string> mapData = handler.mapData;
            List<string> typeData = handler.typeData;
            SqlConnectionStringBuilder conBldr = new SqlConnectionStringBuilder();
            conBldr["server"] = @"(localdb)\MSSQLLocalDB";
            conBldr["Trusted_Connection"] = true;
            conBldr["Integrated Security"] = "SSPI";
            conBldr["Initial Catalog"] = "PROG260FA23";
            string conStr = conBldr.ToString();

            //inserts data in to Map_Location table
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                for (int x = 0; x < mapData.Count; x++)
                {
                    using (var command = new SqlCommand(mapData[x], connection))
                    {
                        var query = command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }

            //inserts data in to Type table
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                for (int x = 0; x < typeData.Count; x++)
                {
                    using (var command = new SqlCommand(typeData[x], connection))
                    {
                        var query = command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }

            //inserts data in to Character table
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                for (int x = 0; x < characterData.Count; x++)
                {
                    using (var command = new SqlCommand(characterData[x], connection))
                    {
                        var query = command.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }

            //writes a full report with all character stats
            StreamWriter reportWriter = new StreamWriter("..\\..\\..\\Files\\Full Report.txt");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string inline = "SELECT [dbo].[Character].Character, [dbo].[Character_Type].Type, [dbo].[Character_Map_Location].Map_Location, [dbo].[Character].Original_Character, [dbo].[Character].Sword_Fighter, [dbo].[Character].Magic_User FROM [dbo].[Character] INNER JOIN [dbo].[Character_Type] ON [dbo].[Character_Type].ID = [dbo].[Character].TypeID INNER JOIN [dbo].[Character_Map_Location] ON [dbo].[Character_Map_Location].ID = [dbo].[Character].Map_LocationID";
                using (var command = new SqlCommand(inline, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)}, {reader.GetValue(1)}, {reader.GetValue(2)}, {reader.GetValue(3)}, {reader.GetValue(4)}";

                        reportWriter.WriteLine(value);
                    }
                    reader.Close();
                }
                connection.Close();
                
            }
            //adds characters with null values to the full stats
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string inline = "SELECT [dbo].[Character].Character, [dbo].[Character_Type].Type, [dbo].[Character_Map_Location].Map_Location, [dbo].[Character].Original_Character, [dbo].[Character].Sword_Fighter, [dbo].[Character].Magic_User FROM [dbo].[Character] LEFT OUTER JOIN [dbo].[Character_Type] ON [dbo].[Character_Type].ID = [dbo].[Character].TypeID LEFT OUTER JOIN [dbo].[Character_Map_Location] ON [dbo].[Character_Map_Location].ID = [dbo].[Character].Map_LocationID WHERE [dbo].[Character].Map_LocationID is NULL OR [dbo].[Character].TypeID is NULL";
                using (var command = new SqlCommand(inline, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)}, {reader.GetValue(1)}, {reader.GetValue(2)}, {reader.GetValue(3)}, {reader.GetValue(4)}";

                        reportWriter.WriteLine(value);
                    }
                    reader.Close();
                }
                connection.Close();

            }
            reportWriter.Close();

            //writes names of characters without a map
            StreamWriter lostWriter = new StreamWriter("..\\..\\..\\Files\\Lost.txt");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string inline = "SELECT [dbo].[Character].Character FROM [dbo].[Character] LEFT OUTER JOIN [dbo].[Character_Map_Location] ON [dbo].[Character_Map_Location].ID = [dbo].[Character].Map_LocationID WHERE [dbo].[Character_Map_Location].Map_Location is NULL";
                using (var command = new SqlCommand(inline, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)}";

                        lostWriter.WriteLine(value);
                    }
                    reader.Close();
                }
                connection.Close();

            }
            lostWriter.Close();

            //writes non human characters that has a sword
            StreamWriter swordWriter = new StreamWriter("..\\..\\..\\Files\\SwordNonHuman.txt");
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string inline = "SELECT [dbo].[Character].Character FROM [dbo].[Character] INNER JOIN [dbo].[Character_Type] ON [dbo].[Character_Type].ID = [dbo].[Character].TypeID WHERE [dbo].[Character_Type].Type <> 'Human' AND [dbo].[Character].Sword_Fighter = 'TRUE'";
                using (var command = new SqlCommand(inline, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var value = $"{reader.GetValue(0)}";

                        swordWriter.WriteLine(value);
                    }
                    reader.Close();
                }
                connection.Close();

            }
            swordWriter.Close();
        }
    }
}