using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.ConsoleColor;

namespace Week1DungeonCrawler
{
    //ReadKey() method learned from https://learn.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-7.0
    public class Game
    {
        string title = " _____                 _         _____           _   _       ______            \r\n/  __ \\               | |       /  __ \\         | | | |      | ___ \\           \r\n| /  \\/ __ _ _ __   __| |_   _  | /  \\/ __ _ ___| |_| | ___  | |_/ /   _ _ __  \r\n| |    / _` | '_ \\ / _` | | | | | |    / _` / __| __| |/ _ \\ |    / | | | '_ \\ \r\n| \\__/\\ (_| | | | | (_| | |_| | | \\__/\\ (_| \\__ \\ |_| |  __/ | |\\ \\ |_| | | | |\r\n \\____/\\__,_|_| |_|\\__,_|\\__, |  \\____/\\__,_|___/\\__|_|\\___| \\_| \\_\\__,_|_| |_|\r\n                          __/ |                                                \r\n                         |___/                                                 ";
        string objective = "You have three lives to pass three levels to make it through the Candy Castle. Each level asks one question that you must answer correctly to reach the next level. If you answer incorrectly, you lose one life. If you lose all lives, the game is over.";
        List<string> lvlTxt = new List<string>();
       
        Player p = new Player("Test", 1, 3);
        Level levels = new Level();
        string s, ans;

        bool cont = true;

        public void Start()
        {
            lvlTxt.Add(" _                    _   _____            \r\n| |                  | | |  _  |           \r\n| |     _____   _____| | | | | |_ __   ___ \r\n| |    / _ \\ \\ / / _ \\ | | | | | '_ \\ / _ \\\r\n| |___|  __/\\ V /  __/ | \\ \\_/ / | | |  __/\r\n\\_____/\\___| \\_/ \\___|_|  \\___/|_| |_|\\___|\r\n                                           ");
            lvlTxt.Add(" _                    _   _____             \r\n| |                  | | |_   _|            \r\n| |     _____   _____| |   | |_      _____  \r\n| |    / _ \\ \\ / / _ \\ |   | \\ \\ /\\ / / _ \\ \r\n| |___|  __/\\ V /  __/ |   | |\\ V  V / (_) |\r\n\\_____/\\___| \\_/ \\___|_|   \\_/ \\_/\\_/ \\___/ \r\n                                            ");
            lvlTxt.Add(" _                    _   _____ _                   \r\n| |                  | | |_   _| |                  \r\n| |     _____   _____| |   | | | |__  _ __ ___  ___ \r\n| |    / _ \\ \\ / / _ \\ |   | | | '_ \\| '__/ _ \\/ _ \\\r\n| |___|  __/\\ V /  __/ |   | | | | | | | |  __/  __/\r\n\\_____/\\___| \\_/ \\___|_|   \\_/ |_| |_|_|  \\___|\\___|\r\n                                                    ");

            //game setup
            WriteLine("Welcome to ");
            setTextColor(Magenta);
            WriteLine(title);
            resetColor();
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            WriteLine("What is your name?");
            s = ReadLine();
            p.updateName(s);
            Write("Welcome ");
            setTextColor(Cyan);
            Write(p.getName());
            resetColor();
            WriteLine("!");
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            WriteLine(objective);
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();

            //level setup
            while (playerContinue() == true)
            {
                play();
            }

        }

        public void setTextColor(ConsoleColor c)
        {
            ForegroundColor = c;
        }

        public void resetColor()
        {
            ForegroundColor = White;
        }

        //checks if the player is right
        public void isPlayerRight()
        {
            int correctAns = levels.getCorrectAnswer(p.getLevel());
            if (ans.ToUpper() == correctAns.ToString())
            {
                Write("That answer is ");
                setTextColor(Cyan);
                Write("Correct");
                resetColor();
                WriteLine(".");
                p.updateLevel();
                WriteLine("Press any key to continue.");
                ReadKey(false);
            } else
            {
                Write("That answer is ");
                setTextColor(Magenta);
                Write("Incorrect");
                resetColor();
                Write(", sorry.");
                p.updateLives();
                WriteLine($"You have {p.getLives()} lives left.");
                WriteLine("Press any key to continue.");
                ReadKey(false);
            }
            Clear();
        }

        //gets if the player can continue
        public bool playerContinue()
        {
            if (p.getLives() > 0 && p.getLevel() < 4)
            {
                return true;
            }
            else if (p.getLives() == 0)
            {
                setTextColor(Magenta);
                WriteLine(" _____                        _____                \r\n|  __ \\                      |  _  |               \r\n| |  \\/ __ _ _ __ ___   ___  | | | |_   _____ _ __ \r\n| | __ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|\r\n| |_\\ \\ (_| | | | | | |  __/ \\ \\_/ /\\ V /  __/ |   \r\n \\____/\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   ");
                resetColor();
                Environment.Exit(0);
            }
            else
            {
                setTextColor(Cyan);
                WriteLine("__   __            _    _ _       \r\n\\ \\ / /           | |  | (_)      \r\n \\ V /___  _   _  | |  | |_ _ __  \r\n  \\ // _ \\| | | | | |/\\| | | '_ \\ \r\n  | | (_) | |_| | \\  /\\  / | | | |\r\n  \\_/\\___/ \\__,_|  \\/  \\/|_|_| |_|\r\n                                  ");
                resetColor();
                Environment.Exit(0);
            }
            return false;
        }

        //method that runs the gameplay
        public void play()
        {
            setTextColor(Magenta);
            WriteLine(lvlTxt[p.getLevel() - 1]);
            ResetColor();
            WriteLine("Press any key to continue.");
            ReadKey(false);
            Clear();
            levels.writeQuestions(p.getLevel());
            ans = ReadLine();
            isPlayerRight();
        }
    }
}