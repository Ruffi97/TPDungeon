﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{    
    class Program
    {
        public static int room_number = 1;
        public static bool gameRunning = true;
        public static bool haveSword = false;
        public static int health = 5;
        static void Main(string[] args)
        {
            Dictionary<string, string> sentenceWhenMoving = new Dictionary<string, string>();
            sentenceWhenMoving.Add("n", "> going to north...");
            sentenceWhenMoving.Add("s", "> going to south...");
            sentenceWhenMoving.Add("e", "> going to east...");
            sentenceWhenMoving.Add("w", "> going to west...");

            string str = File.ReadAllText("Data.json");
            List<Dictionary<string, int>> roomsDirections = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(str);

            Console.OutputEncoding = Encoding.UTF8;
            Intro();
            int room_number = 1;

            while (gameRunning)
            {               
                if (room_number == 3 || room_number == 5 || room_number == 12 || room_number == 20 || room_number == 21 || room_number == 23)
                {
                    if (room_number == 5 || room_number == 12 || room_number == 20 || room_number == 23)
                    {
                        Trap();
                        room_number = Room(room_number, sentenceWhenMoving, roomsDirections);
                    }
                    else if (room_number == 21)
                    {
                        Win();
                        room_number = Restart(room_number);
                    }
                    else if (room_number == 3)
                    {
                        if (haveSword)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You already own the legendary sword !");
                            room_number = 4;
                        }
                        else
                        {
                            Sword();
                            room_number = 4;
                        }
                    }
                }
                else
                {
                    Random rnd = new Random();
                    int possibleAttack = rnd.Next(0, 4);
                    if (possibleAttack == 3)
                    {
                        MonsterAttack();
                    }
                    room_number = Room(room_number, sentenceWhenMoving, roomsDirections);                   
                }
            }
        }
        static void Intro()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("************ Welcome to the MAZE ************");
            Console.WriteLine("*********************************************");
            Console.WriteLine("");
            Console.WriteLine("You are lost inside a Maze, try to escape...");
            Console.WriteLine("");
            Console.ReadKey();
            Console.Clear();
        }
        private static void DisplayStandardRoom(Dictionary<string, int> configForCurrentRoom)
        {
            bool canGoNorth = configForCurrentRoom.ContainsKey("n");
            bool canGoSouth = configForCurrentRoom.ContainsKey("s");
            bool canGoEast = configForCurrentRoom.ContainsKey("e");
            bool canGoWest = configForCurrentRoom.ContainsKey("w");
            Console.WriteLine("");
            generateRoom(canGoNorth, canGoSouth, canGoEast, canGoWest);
            Console.WriteLine("");
            Console.Write("There are " + configForCurrentRoom.Count() + " door(s) in your room: ");
            if (canGoNorth)
                Console.Write("(n)orth ");
            if (canGoSouth)
                Console.Write("(s)outh ");
            if (canGoEast)
                Console.Write("(e)ast ");
            if (canGoWest)
                Console.Write("(w)est ");
            Console.WriteLine("where do you want to go ? ");
        }
        static void generateRoom(bool canGoNorth, bool canGoSouth, bool canGoEast, bool canGoWest)
        {
            for (int y = 0; y < 7; y++)
            {
                string currentTextLine = "";
                for (int x = 0; x < 17; x++)
                {
                    bool isInside = x > 0 && x < 16 && y > 0 && y < 6;
                    bool northDoor = canGoNorth && x == 8 && y == 0;
                    bool southDoor = canGoSouth && x == 8 && y == 6;
                    bool eastDoor = canGoEast && x == 16 && y == 3;
                    bool westDoor = canGoWest && x == 0 && y == 3;
                    bool isDoor = northDoor || southDoor || eastDoor || westDoor;
                    if (isInside || isDoor)
                    {
                        currentTextLine += " ";
                    }
                    else
                    {
                        currentTextLine += "#";
                    }
                }
                Console.WriteLine(currentTextLine);
            }
        }
        static int Restart(int roomID)
        {
            Console.WriteLine("Play again ? ('y' for yes, 'n' for no)");
            string restart = Console.ReadLine();
            if (restart.Contains('y') || restart.Contains('n'))
            {
                if (restart == "y")
                {
                    health = 5;
                    roomID = 1;
                }
                else if (restart == "n")
                {
                    gameRunning = false;
                }
            }
            else
            {
                Console.WriteLine("invalid responce");
                Console.ReadKey();
            }
            return roomID;
        }
        static int Room(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
        {
            Dictionary<string, int> configForCurrentRoom = roomsDirections[roomID];
            Random rnd = new Random();           
            DisplayStandardRoom(configForCurrentRoom);          
            string choice = Console.ReadLine();
            if (configForCurrentRoom.ContainsKey(choice))
            {
                roomID = configForCurrentRoom[choice];
                if (sentenceWhenMoving.ContainsKey(choice))
                {
                    Console.Clear();
                    Console.WriteLine(sentenceWhenMoving[choice]);                                     
                }
            }
            else
            {
                Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
            }
            return roomID;
        }
        static void MonsterAttack()
        {
            Random rnd = new Random();
            Console.WriteLine("                                 _.--\"\"--._                        ");
            Console.WriteLine("      .                        .\"          \".                      ");
            Console.WriteLine("     / \\    ,^.         /(     |            |      )\\              ");
            Console.WriteLine("    /   `---. |--'\\    (  \\__..'--   --   --'\"\"-.-'  )           ");
            Console.WriteLine("    |        :|    `>   '.     l_..-------.._l      .'               ");
            Console.WriteLine("    |      __l;__ .'      \"-.__.||_.-'v'-._||`\"----\"                 ");
            Console.WriteLine("     \\  .-' | |  `              l._       _.'                        ");
            Console.WriteLine("      \\/    | |                   l`^^'^^'j                          ");
            Console.WriteLine("            | |                _   \\_____/     _                     ");
            Console.WriteLine("            | |               l `--__)-'(__.--' |                    ");
            Console.WriteLine("            | |               | /`---``-----'\"\\ | ,-----.          ");
            Console.WriteLine("            | |               )/  `--' '---'   \'-'   ____`-.        ");
            Console.WriteLine("            | |              //  `-'  '`----'  /  ,-'    I`. \\       ");
            Console.WriteLine("          _ L |_            //  `-.-.'`-----' /  /  |   |   \\ \\      ");
            Console.WriteLine("         '._' / \\         _/(   `/   )- ---' ;  /__.J   L.__.\\ :     ");
            Console.WriteLine("          `._;/7(-.......'  /        ) (     |  |            | |     ");
            Console.WriteLine("          `._;l _'--------_/        )-'/     :  |___.    _._./ ;     ");
            Console.WriteLine("            | |                 .__ )-'\\  __  \\  \\  I   1   / /      ");
            Console.WriteLine("            `-'                /   `-\\-(-'   \\ \\  `.|   | ,' /       ");
            Console.WriteLine("                               \\__  `-'    __/  `-. `---'',-'        ");
            Console.WriteLine("                                  )-._.-- (        `-----'           ");
            Console.WriteLine("                                 )(  l\\ o ('..-.                     ");
            Console.WriteLine("                           _..--' _'-' '--'.-. |                     ");
            Console.WriteLine("                    __,,-'' _,,-''            \\ \\                    ");
            Console.WriteLine("                   f'. _,,-'                   \\ \\                   ");
            Console.WriteLine("                  ()--  |                       \\ \\                  ");
            Console.WriteLine("                    \\.  |                       /  \\                 ");
            Console.WriteLine("                      \\ \\                      |._  |                ");
            Console.WriteLine("                       \\ \\                     |  ()|                ");
            Console.WriteLine("                        \\ \\                     \\  /                 ");
            Console.WriteLine("                         ) `-.                   | |                 ");
            Console.WriteLine("                        // .__)                  | |                 ");
            Console.WriteLine("                     _.//7'                      | |                 ");
            Console.WriteLine("                   '---'                         |_|                 ");
            Console.WriteLine("                                                (| |                 ");
            Console.WriteLine("                                                 |  \\                ");
            Console.WriteLine("                                                 |lll|               ");
            Console.WriteLine("                                                 |||||               ");
            Console.WriteLine("");
            Console.WriteLine("A monster's attack !");
            Console.ReadKey();
            if (haveSword)
            {
                Console.WriteLine("Choice 1: Run for your life \nChoice 2: fight ");
                int battleChoice = Console.Read();
                if (battleChoice != 1 && battleChoice != 2)
                {
                    Console.WriteLine("THIS CHOICE DOESN'T EXIST!");
                }
                else
                {
                    if (battleChoice == 1)
                    {
                        int escape = rnd.Next(1, 3);
                        if (escape != 3)
                        {
                            Console.WriteLine("escape impossible !");
                            health--;
                            Console.WriteLine("Life's points: " + health);
                            Console.ReadKey();
                            if (health == 0)
                            {
                                GameOver();
                            }
                            else { MonsterAttack(); }
                        }
                    }
                    else
                    {
                        int attack = rnd.Next(1, 4);
                        if (attack == 4)
                        {
                            Console.WriteLine("You miss your target !");
                            health--;
                            Console.WriteLine("Life's points: " + health);
                            Console.ReadKey();
                            if (health == 0)
                            {
                                GameOver();
                            }
                            else { MonsterAttack(); }
                        }
                    }
                }
            }
            else
            {
                int escape = rnd.Next(1, 2);
                if (escape == 2)
                {
                    Console.WriteLine("escape impossible !");
                    health--;
                    Console.WriteLine("Life's points: " + health);
                    Console.ReadKey();
                    if (health == 0)
                    {
                        GameOver();
                    }
                    else { MonsterAttack(); }                   
                }                
            }
            
        }
        private static void Sword()
        {
            haveSword = true;

            Console.WriteLine("      .     ");
            Console.WriteLine("     / \\    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("     | |    ");
            Console.WriteLine("   `--8--'  ");
            Console.WriteLine("      8     ");
            Console.WriteLine("      O     ");

            Console.WriteLine(">>>>>>>>>>>> Congratulations, you found the legendary Master Sword !");
            Console.ReadKey();
        }
        private static void Trap()
        {
            health--;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(">>>>>>>>>>>> It's a trap... you take damage :/");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Life's points: " + health);
            Console.ReadKey();
            if (health == 0)
            {
                GameOver();
            }
        }
        private static void GameOver()
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("YOUR LIFE'S POINTS IS FALL AT 0");           
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("YOU ARE DEATH !\n");
            Console.ReadKey();
            Restart(room_number);
        }
        private static void Win()
        {
            Console.Clear();
            Console.WriteLine("        ______        ");
            Console.WriteLine("     ,-' ;  ! `-.     ");
            Console.WriteLine("    / :  !  :  . \\    ");
            Console.WriteLine("   |_ ;   __:  ;  |   ");
            Console.WriteLine("   )| .  :)(.  !  |   ");
            Console.WriteLine("   |\"    (##)  _  |   ");
            Console.WriteLine("   |  :  ;`'  (_) (   ");
            Console.WriteLine("   |  :  :  .     |   ");
            Console.WriteLine("   )_ !  ,  ;  ;  |   ");
            Console.WriteLine("   || .  .  :  :  |   ");
            Console.WriteLine("   |\" .  |  :  .  |   ");
            Console.WriteLine("   |____.-----.___|   ");
            Console.WriteLine();
            Console.WriteLine(">>>>>>>>>>>> You found the EXIT... Congratulations:)");
            Console.ReadKey();
        }
    }
}
