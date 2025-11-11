using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreDatabases
{
    internal class DatabaseHandler
    {
        public List<string> mapData = new List<string>();
        public List<string> typeData = new List<string>();
        public List<string> charData = new List<string>();
        public void Run()
        {
            TableReader tableReader = new TableReader();
            tableReader.Read("Chars.csv");
            List<string[]> charInfo = tableReader.info;
            List<string> maps = createMaps(charInfo);
            List<string> types = createTypes(charInfo);
            mapData = createMapTableData(maps);
            typeData = createTypeTableData(types);
            charData = createCharTableData(charInfo);
            charData.ForEach(a => Console.WriteLine(a + "\n"));
        }

        //creates data for the Map_Location table
        List<string> createMapTableData(List<string> data)
        {
            List<string> result = new List<string>();
            for (int x = 0; x < data.Count; x++)
            {
                if (data[x].Equals("LeChuck's ship"))
                {
                    data[x] = "LeChuck''s ship";
                }
                string inline = $"INSERT [dbo].[Character_Map_Location] ([Map_Location]) VALUES ('{data[x]}')";
                result.Add(inline);
            }
            return result;
        }

        //creates data for the Type table
        List<string> createTypeTableData(List<string> data)
        {
            List<string> result = new List<string>();
            for (int x = 0; x < data.Count; x++)
            {
                string inline = $"INSERT [dbo].[Character_Type] ([Type]) VALUES ('{data[x]}')";
                result.Add(inline);
            }
            return result;
        }

        //creates data for the character table
        //insert data with FK help from https://dba.stackexchange.com/questions/46410/how-do-i-insert-a-row-which-contains-a-foreign-key
        List<string> createCharTableData(List<string[]> data)
        {
            List<string> result = new List<string>();
            for (int x = 0; x < data.Count; x++)
            {
                if (data[x][2].Equals("LeChuck's ship"))
                {
                    data[x][2] = "LeChuck''s ship";
                }
                string inline = $"INSERT [dbo].[Character] ([Character], [TypeID], [Map_LocationID], [Original_Character], [Sword_Fighter], [Magic_User]) VALUES ('{data[x][0]}', (SELECT ID from [dbo].[Character_Type] WHERE Type='{data[x][1]}'), (SELECT ID from [dbo].[Character_Map_Location] WHERE Map_Location='{data[x][2]}'), '{data[x][3]}', '{data[x][4]}', '{data[x][5]}')";
                result.Add(inline);
            }
            return result;
        }

        //seperates the maps from the read data and eliminates redundancy
        List<string> createMaps(List<string[]> data)
        {
            List<string> newMaps = new List<string>();
            for (int x = 0 ; x < data.Count ; x++)
            {
                if (!newMaps.Contains(data[x][2]) && !data[x][2].Equals(""))
                {
                    newMaps.Add(data[x][2]);
                }
            }
            return newMaps;
        }

        //seperates the types from the read data and eliminates redundancy
        List<string> createTypes(List<string[]> data)
        {
            List<string> newTypes = new List<string>();
            for (int x = 0; x < data.Count; x++)
            {
                if (!newTypes.Contains(data[x][1]) && !data[x][1].Equals(""))
                {
                    newTypes.Add(data[x][1]);
                }
            }
            return newTypes;
        }
    }
}
