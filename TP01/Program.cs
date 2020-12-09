using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            /*List<Dictionary<string, int>> roomsDirections = new List<Dictionary<string, int>>();
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 5 },
            { "e", 1 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 6 },
            { "w", 0 },
            { "e", 2 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 7 },
            { "w", 1 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "e", 4 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 3 },
            { "n", 9 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 0 },
            { "n", 10 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 1 },
            { "n", 11 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 2 },
            { "w", 8 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 7 },
            { "n", 13 },
            { "e", 9 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 8 },
            { "s", 4 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 15 },
            { "e", 11 },
            { "s", 5 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 6 },
            { "e", 12 },
            { "w", 10 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 11 },
            { "e", 13 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 12 },
            { "e", 14 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 13 },
            { "n", 19 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 10 },
            { "n", 20 },
            { "e", 16 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "w", 15 },
            { "e", 17 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "n", 2 },
            { "w", 16 },
            { "e", 22 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 13 },
            { "w", 17 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 14 },
            { "n", 24 }
        });
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 15 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "e", 22 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 17 },
            { "w", 21 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "e", 24 }
        }); 
            roomsDirections.Add(new Dictionary<string, int>() {
            { "s", 19 },
            { "w", 23 }
        });
            string jsonString = JsonConvert.SerializeObject(roomsDirections);
            Console.WriteLine(jsonString);*/
            string str = File.ReadAllText("Data.json");
            List<Dictionary<string, int>> roomsDirections = JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(str);

            Console.OutputEncoding = Encoding.UTF8;
            Intro();            
            int room_number = 1;
            
            while (MyClasse.gameRunning)
            {               
                if (room_number == 20 || room_number == 21 || room_number == 23)
                {
                    if (room_number == 20 || room_number == 23)
                    {
                        GameOver();
                        room_number = Restart(room_number);
                    }
                    else
                    {
                        Win();
                        room_number = Restart(room_number);
                    }
                }
                else
                {
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
        static int Room(int roomID, Dictionary<string, string> sentenceWhenMoving, List<Dictionary<string, int>> roomsDirections)
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
