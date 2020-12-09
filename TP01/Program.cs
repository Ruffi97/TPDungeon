using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    static class MyClasse
    {
        public static bool gameRunning = true;
        
    }
    class Program
    {        
        static void Main(string[] args)
        {
            Dictionary<string, string> sentenceWhenMoving = new Dictionary<string, string>();
            sentenceWhenMoving.Add("n", "> going to north...");
            sentenceWhenMoving.Add("s", "> going to south...");
            sentenceWhenMoving.Add("e", "> going to east...");
            sentenceWhenMoving.Add("w", "> going to west...");

            List<Dictionary<string, int>> roomsDirections = new List<Dictionary<string, int>>();
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 3 },
            { "e", 1 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 4 },
            { "w", 0 },
            { "e", 2 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 5 },
            { "w", 1 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 0 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 1 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 2 }
        });

            Console.OutputEncoding = Encoding.UTF8;
            Intro();            
            int room_number = 1;
            
            while (MyClasse.gameRunning)
            {
                if (room_number == 0)
                {
                    room_number = Room0(room_number, sentenceWhenMoving, roomsDirections);
                }
                else if (room_number == 1)
                {
                    room_number = Room1(room_number, sentenceWhenMoving, roomsDirections);
                }
                else if (room_number == 2)
                {
                    room_number = Room2(room_number, sentenceWhenMoving, roomsDirections);
                }
                else if (room_number == 3)
                {
                    GameOver();
                    room_number = Restart(room_number);
                }
                else if (room_number == 4)
                {
                    room_number = Room4(room_number, sentenceWhenMoving, roomsDirections);
                }
                else if (room_number == 5)
                {
                    Win();
                    room_number = Restart(room_number);
                }
            }
        }

        private static int Room4(int room_number, Dictionary<string, string> sentenceWhenMoving)
        {
            throw new NotImplementedException();
        }

        private static int Room0(int room_number, Dictionary<string, string> sentenceWhenMoving)
        {
            throw new NotImplementedException();
        }

        private static int Room2(int room_number, Dictionary<string, string> sentenceWhenMoving)
        {
            throw new NotImplementedException();
        }

        private static int Room1(int room_number, Dictionary<string, string> sentenceWhenMoving)
        {
            throw new NotImplementedException();
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
                    roomID = 1;
                }
                if (restart == "n")
                {
                    MyClasse.gameRunning = false;
                }
            }
            else
            {
                Console.WriteLine("invalid responce");
                Console.ReadKey();
            }
            return roomID;

        }
        static int Room0(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
        {            
            Dictionary<string, int> configForCurrentRoom = roomsDirections[roomID];
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
        static int Room1(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
        {                      
            Dictionary<string, int> configForCurrentRoom = roomsDirections[roomID];
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
        static int Room2(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
        {          
            Dictionary<string, int> configForCurrentRoom = roomsDirections[roomID];
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
        static int Room4(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
        {           
            Dictionary<string, int> configForCurrentRoom = roomsDirections[roomID];
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
