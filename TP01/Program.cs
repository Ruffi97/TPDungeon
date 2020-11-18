using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    class Program
    {
        static void room1(int roomID)
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
                Console.WriteLine("> going to north...");
                roomID = 4;
            }
            else if (choice == "e")
            {
                Console.Clear();
                Console.WriteLine("> going to east...");
                roomID = 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
        }

        static void room2(int roomID)
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
                Console.WriteLine("> going to north...");
                roomID = 5;
            }
            else if (choice == "w")
            {
                Console.Clear();
                Console.WriteLine("> going to west...");
                roomID = 1;
            }
            else if (choice == "e")
            {
                Console.Clear();
                Console.WriteLine("> going to east...");
                roomID = 3;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
        }

        static void room3(int roomID)
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
                Console.WriteLine("> going to north...");
                roomID = 6;
            }
            else if (choice == "w")
            {
                Console.Clear();
                Console.WriteLine("> going to west...");
                roomID = 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
        }

        static void room5(int roomID)
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
                Console.WriteLine("> going to south...");
                roomID = 2;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
        }

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
            int room_number = 2;

            while (gameRunning)
            {
                if (room_number == 1)
                {
                    room1(room_number);
                }
                else if (room_number == 2)
                {
                    room2(room_number);
                }
                else if (room_number == 3)
                {
                    room3(room_number);
                }
                else if (room_number == 4)
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
                    gameRunning = false;
                }
                else if (room_number == 5)
                {
                    room5(room_number);
                }
                else if (room_number == 6)
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
                    gameRunning = false;
                }
            }
        }
    }
}
