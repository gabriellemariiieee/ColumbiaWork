using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Week1DungeonCrawler
{
    internal class Level
    {
        //2D array declaration from https://www.programiz.com/csharp-programming/multidimensional-arrays#:~:text=Two%2DDimensional%20Array%20Declaration,an%20array%20with%203%20elements
        public string[,] questions = new string[3,4];

        public Level() {
            questions[0, 0] = "What year did Hershey sell their first candy bar?";
            questions[0, 1] = "1. 1876";
            questions[0, 2] = "2. 1990";
            questions[0, 3] = "3. 1945";
            questions[1, 0] = "What is the top-selling candy in the US?";
            questions[1, 1] = "1. Reese's Peanut Butter Cups";
            questions[1, 2] = "2. M&M's";
            questions[1, 3] = "3. KitKat";
            questions[2, 0] = "What manufacturer sold Willy Wonka Candy?";
            questions[2, 1] = "1. Hershey";
            questions[2, 2] = "2. Mars";
            questions[2, 3] = "3. Nestle";
        }

        //print question based on player level
        public void writeQuestions(int l)
        {
            for (int x = 0; x < 4; x++)
            {
                WriteLine(questions[l - 1, x]);
            }
        }

        //returns correct answers to questions
        public int getCorrectAnswer(int l)
        {
            if (l == 1)
            {
                return 2;
            } else if (l == 2)
            {
                return 1;
            } else
            {
                return 3;
            }
        }
    }
}