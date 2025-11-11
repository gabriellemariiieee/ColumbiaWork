namespace Week2Fundamentals
{
    //help from https://canvas.colum.edu/courses/34162/pages/fundamentals-guide?module_item_id=2173986
    internal class Program
    {
        static void Main(string[] args)
        {
            GameInfo gameInfo = new GameInfo();
            List<Info> gameData = new List<Info>();
            gameData = gameInfo.MetaData;

            Console.WriteLine($"There are {gameData.Count} games.");
            Console.WriteLine($"{getGameGenre(gameData)} is the most frequent genre.");
            var list = getMapCharacters(gameData);
            Console.WriteLine($"The games with the most map characters are ");
            foreach (String s in list)
            {
                foreach (Info info in gameData)
                {
                    if (info.MapNames.Contains(s))
                    {
                        Console.WriteLine(info.Name + ": " + s);
                    }
                }
            }
            createDictionary( gameData );
            printZ(gameData );
        }

        //gets most frequent game genre
        static string getGameGenre(List<Info> data)
        {
            int pC = 0, a = 0, tRPG = 0;
            foreach(Info info in data)
            {
                if(info.Genre == "Point & Click")
                {
                    pC++;
                } else if (info.Genre == "Adventure")
                {
                    a++;
                } else
                {
                    tRPG++;
                }
            }

            if ((pC > a) && (pC > tRPG))
            {
                return "Point & Click";
            } else if ((a > tRPG) && (a > pC))
            {
                return "Adventure";
            } else if ((tRPG > a) && (tRPG > pC))
            {
                return "Tactical RPG";
            } else
            {
                return null;
            }
        }

        //gets maps with the most characters
        static List<string> getMapCharacters(List<Info> data)
        {
            List<string> maps = new List<string>();
            List<string> m = new List<string>();
            int x = 0;

            foreach(Info info in data)
            {
                for (int i = 0; i < info.MapNames.Count(); i++)
                {
                    maps.Add(info.MapNames[i]);
                }                
            }

            //getting string length without spaces from https://stackoverflow.com/questions/16608691/length-of-string-without-spaces-c#:~:text=You%20can%20use%20a%20combination,Length%20%2D%20sText
            maps = maps.OrderBy(x => x.Length - x.Count(Char.IsWhiteSpace)).ToList();
            x = maps.Last().Length - maps.Last().Count(Char.IsWhiteSpace);

            m = maps.Where(a => (a.Length - a.Count(Char.IsWhiteSpace)).Equals(x)).ToList();
            return m;
        }

        //puts id and data in dictionary and prints
        static void createDictionary(List<Info> data)
        {
            Dictionary<int, Info> gameDictionary = new Dictionary<int, Info>();
            foreach (Info info in data)
            {
                gameDictionary.Add(info.ID, info);
            }

            foreach(KeyValuePair<int, Info> pair in gameDictionary)
            {
                Console.Write($"ID: {pair.Key.ToString()}, Name: {pair.Value.Name}, Genre: {pair.Value.Genre}, Map Names: ");
                foreach(string map in pair.Value.MapNames)
                {
                    Console.WriteLine(map);
                }
            }
        }

        //gets maps with z
        static void printZ(List<Info> data)
        {
            List<String> maps = new List<String>();
            List<String> z = new List<String>();
            foreach (Info info in data)
            {
                for (int i = 0; i < info.MapNames.Count(); i++)
                {
                    maps.Add(info.MapNames[i]);
                }
            }

            z = maps.Where(a => a.Contains('z')).ToList();
            Console.Write("Maps that contain Z: ");
            foreach(String map in z)
            {
                Console.WriteLine(map);
            }
            
        }
    }
}