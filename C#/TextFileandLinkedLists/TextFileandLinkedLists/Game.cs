using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TextFileandLinkedLists
{
    internal class Game
    {
        string title = "   _____                          __                 __________              \r\n  /     \\   ____   ____   _______/  |_  ___________  \\______   \\__ __  ____  \r\n /  \\ /  \\ /  _ \\ /    \\ /  ___/\\   __\\/ __ \\_  __ \\  |       _/  |  \\/    \\ \r\n/    Y    (  <_> )   |  \\\\___ \\  |  | \\  ___/|  | \\/  |    |   \\  |  /   |  \\\r\n\\____|__  /\\____/|___|  /____  > |__|  \\___  >__|     |____|_  /____/|___|  /\r\n        \\/            \\/     \\/            \\/                \\/           \\/ ";
        string objective = "You have three rooms to make it through the dungeon. Each room has a monster that you must defeat to go to the next room. If you die, you lose one life. If you lose all lives, the game is over.";
        string path = @"..\\..\\..\\textfiles";
        List<Monster> monsters = new List<Monster>();
        List<Room> rooms = new List<Room>();
        List<Room> levels = new List<Room>();

        Player p = new Player("Player 1", 0, 3);
        string s;
        int playerChoice, room;
        bool cont = true;

        LinkedList<String> wins = new LinkedList<String>();

        public void Start()
        {
            createMonsters(monsters, path + "\\Stats.txt");
            createRooms(rooms, monsters);
            WriteLine("Welcome to ");
            WriteLine(title);
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            WriteLine("What is your name?");
            s = ReadLine();
            p.updateName(s);
            Write("Welcome ");
            Write(p.getName());
            WriteLine("!");
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            WriteLine(objective);
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            while (cont && rooms.Count != 0)
            {
                WriteLine("Select a room:");
                for(int x = 0; x < rooms.Count; x++)
                {
                    WriteLine(x + 1);
                }
                room = Int32.Parse(ReadLine()) - 1;
                Clear();
                WriteLine($"You've entered the room with a {rooms[room].monster.type} inside. What will you do? \n1.Attack \n2.Defend \n3.Escape");
                playerChoice = Int32.Parse(ReadLine());
                if(playerChoice == 1)
                {
                    fightMonster(rooms, room);
                } else if (playerChoice == 2)
                {
                    defendMonsters(rooms, room);
                    fightMonster(rooms, room);
                }
                if (rooms[room].win)
                {
                    rooms.RemoveAt(room);
                }
            }
            writeResults(levels);
        }

        void createMonsters(List<Monster> m, string p)
        {
            StreamReader sr = new StreamReader(p);
            do
            {
                string line = sr.ReadLine();
                if (line == "Type,HP,MP,AP,DEF")
                {
                    continue;
                }
                else
                {
                    string[] stats = line.Split(' ');
                    Monster mons = new Monster();
                    mons.type = stats[0];
                    mons.hp = Int32.Parse(stats[1]);
                    mons.mp = Int32.Parse(stats[2]);
                    mons.ap = Int32.Parse(stats[3]);
                    mons.def = Int32.Parse(stats[4]);

                    monsters.Add(mons);
                }
            }
            while (sr.Peek() != -1);
            sr.Close();
        }

        void createRooms(List<Room> rooms, List<Monster> mons)
        {
            int id = 0;
            foreach (Monster mon in mons)
            {
                Room room = new Room(id, mon, false);
                rooms.Add(room);
                levels.Add(room);
                id++;
            }
        }

        void fightMonster(List<Room> rooms, int id)
        {
            WriteLine("What attack do you want: \n1.Melee \n2.Range \n3.Retreat");
            int c = Int32.Parse(ReadLine());
            if (rooms[id].monster.type == "Dwarf")
            {
                switch (c)
                {
                    case 1:
                        {
                            WriteLine("The dwarf runs at you knocking you to the floor when you hit him with a club.");
                            rooms[id].win = true;
                            levels[id].win = true;
                            break;
                        }
                    case 2:
                        {
                            WriteLine("You shoot your bow and arrow and the arrow lands in the dwarf's foot allowing you to escape unharmed.");
                            rooms[id].win = true;
                            levels[id].win = true;
                            break;
                        }
                    case 3:
                        {
                            WriteLine("You run in the other direction and don't clear the room.");
                            break;
                        }
                }
            } else if(rooms[id].monster.type == "Mage")
            {
                switch (c)
                {
                    case 1:
                        {
                            WriteLine("You try to charge the Mage but she throws poison at you, killing you.");
                            cont = false;
                            break;
                        }
                    case 2:
                        {
                            WriteLine("You shoot your bow and arrow and the arrow lands in the Mage's chest allowing you to escape unharmed and gain extra HP from a healing potion.");
                            rooms[id].win = true;
                            levels[id].win = true;
                            break;
                        }
                    case 3:
                        {
                            WriteLine("You run in the other direction and don't clear the room.");
                            break;
                        }
                }
            } else
            {
                switch (c)
                {
                    case 1:
                        {
                            WriteLine("You and the knight run at each other when you runs into your sword. Proceed to the next room.");
                            rooms[id].win = true;
                            levels[id].win = true;
                            break;
                        }
                    case 2:
                        {
                            WriteLine("You shoot your bow and arrow but the knight deflects it with his sword sending it back towards you.");
                            cont = false;
                            break;
                        }
                    case 3:
                        {
                            WriteLine("You run in the other direction and don't clear the room.");
                            break;
                        }
                }
            }
        }

        void defendMonsters(List<Room> r, int ro)
        {
            string type = r[ro].monster.type;
            switch (type)
            {
                case "Dwarf":
                    {
                        WriteLine("The dwarf runs at you but you use your shield to block him causing him to stumble back.");
                        break;
                    }
                case "Mage":
                    {
                        WriteLine("The mage takes out a potion but you duck when she throws it.");
                        break;
                    }
                case "Knight":
                    {
                        WriteLine("You take out your shield when the knight runs towards you knocking you both back.");
                        break;
                    }
            }
        }

        void writeResults(List<Room> r)
        {
            foreach(Room room in r)
            {
                if (room.win)
                {
                    wins.AddLast("Win");
                } else
                {
                    wins.AddLast("Loss");
                }
            }
            StreamWriter writer = new StreamWriter(path + "\\Results.txt");
            foreach(String s in wins)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }
    }
}
