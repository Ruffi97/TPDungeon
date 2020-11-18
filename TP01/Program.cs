using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    class Program
    {
        Dictionary<string, string> sentenceWhenMoving = new Dictionary<string, string>();
        sentenceWhenMoving.Add("n", "> going to north...");
        sentenceWhenMoving.Add("s", "> going to south...");
        sentenceWhenMoving.Add("e", "> going to east..."); 
        sentenceWhenMoving.Add("w", "> going to west...");

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("*********************************************");
            Console.WriteLine("************ Welcome to the MAZE ************");
            Console.WriteLine("*********************************************");
            Console.WriteLine("");
            Console.WriteLine("You are lost inside a Maze, try to escape...");
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();

            bool gameRunning = true;
            int room_number = 1;

            while (gameRunning)
            {
                if (room_number == 0)
                {
                    room_number = room1(room_number);
                }
                else if (room_number == 1)
                {
                    room_number = room2(room_number);
                }
                else if (room_number == 2)
                {
                    room_number = room3(room_number);
                }
                else if (room_number == 3)
                {
                    GameOver();
                    gameRunning = false;
                }
                else if (room_number == 4)
                {
                    room_number = room5(room_number);
                }
                else if (room_number == 5)
                {
                    Win();
                    gameRunning = false;
                }
            }
        }      

        static int room0(int roomID, sentenceWhenMoving)
        {
            Console.WriteLine("");
            Console.WriteLine("▄▄▄▄▄▄█ N █▄▄▄▄▄▄ ");
            Console.WriteLine("█               █ ");
            Console.WriteLine("█       ▲       ▀▀");
            Console.WriteLine("█       ☻ ►      E");
            Console.WriteLine("█               ▄▄");
            Console.WriteLine("█               █ ");
            Console.WriteLine("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█ ");
            Console.WriteLine("");
            Console.WriteLine("There are 2 doors in your room: (n)orth,(e)ast, where do you want to go ? ");

            string choice = Console.ReadLine();
            if (choice == "n")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[n]);
                roomID = 3;
            }
            else if (choice == "e")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[e]);
                roomID = 1;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
            return roomID;
        }

        static int room1(int roomID, sentenceWhenMoving)
        {
            Console.WriteLine("");
            Console.WriteLine(" ▄▄▄▄▄▄█ N █▄▄▄▄▄▄ ");
            Console.WriteLine(" █               █ ");
            Console.WriteLine("▀▀       ▲       ▀▀");
            Console.WriteLine("W      ◄ ☻ ►      E");
            Console.WriteLine("▄▄               ▄▄");
            Console.WriteLine(" █               █ ");
            Console.WriteLine(" █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█ ");
            Console.WriteLine("");
            Console.WriteLine("There are 3 doors in your room: (n)orth,(w)est, (e)ast, where do you want to go ? ");

            string choice = Console.ReadLine();
            if (choice == "n")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[n]);
                roomID = 4;
            }
            else if (choice == "w")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[w]);
                roomID = 0;
            }
            else if (choice == "e")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[e]);
                roomID = 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
            return roomID;
        }

        static int room2(int roomID, sentenceWhenMoving)
        {
            Console.WriteLine("");
            Console.WriteLine(" ▄▄▄▄▄▄█ N █▄▄▄▄▄▄");
            Console.WriteLine(" █               █");
            Console.WriteLine("▀▀       ▲       █");
            Console.WriteLine("W      ◄ ☻       █");
            Console.WriteLine("▄▄               █");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
            Console.WriteLine("");
            Console.WriteLine("There are 2 doors in your room: (n)orth and (w)est, where do you want to go ?");
            string choice = Console.ReadLine();
            if (choice == "n")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[n]);
                roomID = 5;
            }
            else if (choice == "w")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[w]);
                roomID = 1;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
            return roomID;
        }

        static int room4(int roomID, sentenceWhenMoving)
        {
            Console.WriteLine("");
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █       ☻       █");
            Console.WriteLine(" █       ▼       █");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █▄▄▄▄▄▄ S ▄▄▄▄▄▄█");
            Console.WriteLine("");
            Console.WriteLine("There is only one door in your room: (s)sud");
            string choice = Console.ReadLine();
            if (choice == "s")
            {
                Console.Clear();
                Console.WriteLine(sentenceWhenMoving[s]);
                roomID = 1;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
            return roomID;
        }
        private static void GameOver()
        {
            Console.WriteLine("");
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine(" █  ■         ■  █");
            Console.WriteLine(" █    ■     ■    █");
            Console.WriteLine(" █      ■ ■      █");
            Console.WriteLine(" █     ■   ■     █");
            Console.WriteLine(" █   ■       ■   █");
            Console.WriteLine(" █▄▄▄▄▄▄   ▄▄▄▄▄▄█");
            Console.WriteLine("");
            Console.WriteLine(">>>>>>>>>>>> It's a trap... you are DEAD :/");
            Console.ReadKey();
        }

        private static void Win()
        {
            Console.WriteLine("");
            Console.WriteLine(" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █      EXIT     █");
            Console.WriteLine(" █       ☻       █");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █               █");
            Console.WriteLine(" █▄▄▄▄▄▄   ▄▄▄▄▄▄█");
            Console.WriteLine("");
            Console.WriteLine(">>>>>>>>>>>> You found the EXIT... Congratulations:)");
            Console.ReadKey();
        }
    }
}
