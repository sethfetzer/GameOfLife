using GameOfLife.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game;
            int[,] gameArray = new int[0,0];
            Random random = new Random();
            string invalidEntry = "Entry value not recognized. setting to random pattern.";
            Console.WriteLine("Welcome to the Game of Life!");
            Console.Write("Preset(1), Manual(2) or Random(3):");
            string option1 = Console.ReadLine();
            string option2;
            switch(option1)
            {
                case "1":
                    Console.WriteLine("Which preset would you like?");
                    Console.Write("Test Example(1), Oscillator blinker(2), Static Life Beehive(3):");
                    option2 = Console.ReadLine();
                    switch (option2)
                    {
                        case "1":
                            gameArray = new int[5, 5]
                                { { 0, 1, 0, 0, 0 },

                                  { 1, 0, 0, 1, 1 },

                                  { 1, 1, 0, 0, 1 },

                                  { 0, 1, 0, 0, 0 },

                                  { 1, 0, 0, 0, 1 } };
                            break;
                            
                        case "2":
                            gameArray = new int[5, 5]
                                { { 0, 1, 0, 0, 0 },

                                  { 0, 1, 0, 0, 0 },

                                  { 0, 1, 0, 0, 0 },

                                  { 0, 0, 0, 0, 0 },

                                  { 0, 0, 0, 0, 0 } };
                            break;
                        case "3":
                            gameArray = new int[5, 5]
                                { { 0, 0, 0, 0, 0 },

                                  { 0, 0, 1, 1, 0 },

                                  { 0, 1, 0, 0, 1 },

                                  { 0, 0, 1, 1, 0 },

                                  { 0, 0, 0, 0, 0 } };
                            break;
                        default:
                            Console.WriteLine("");
                            break;
                    }
                    break;
                case "2":
                    //since this exercise is short on time, any errors push to randomizer.
                    int xSize;
                    int ySize;

                    Console.Write("Please enter the horizontal size of your grid:");
                    if (!int.TryParse(Console.ReadLine(), out xSize))                    
                        Console.WriteLine(invalidEntry);
                    Console.Write("Please enter the vertical size of your grid:");
                    if (!int.TryParse(Console.ReadLine(), out ySize))
                        Console.WriteLine(invalidEntry);
                    //After coding the entire project, I thought to add this manual entry point and realized 
                    //that my x and y axis in the server project are inverted. 
                    List<int[]> tmpArrayList = new List<int[]>();
                    for(int i=0; i< xSize; i++)
                    {
                        Console.WriteLine("Please enter your values (0s and 1s) for row {0}, with no spaces or commas:", i + 1);
                        string rowData = Console.ReadLine();
                        int[] xArray = rowData.ToArray<char>().Select(x => Convert.ToInt32(x.ToString())).ToArray();
                        if (xArray.Length > xSize)
                        {
                            Console.WriteLine(invalidEntry);
                            xArray = new int[xSize];
                            xArray.ToList().ForEach(x => x = random.Next(2));
                        }
                        tmpArrayList.Add(xArray);
                    }
                    int[][] tmpArray = tmpArrayList.ToArray();
                    gameArray = new int[tmpArray.Length, tmpArray[0].Length];
                    for (int x = 0; x< gameArray.GetLength(0); x++)
                        for(int y =0; y< gameArray.GetLength(1); y++)
                        {
                            gameArray[x, y] = tmpArray[x][y];
                        }
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine(invalidEntry);
                    break;

            }

            if (gameArray.GetLength(0)>0)
                game = new Game(gameArray);
            else
                game = new Game();
            Console.WriteLine(game.PrintStatus());

            while (Console.ReadLine() != "q")
            {
                game.StepForward();
                Console.WriteLine(game.PrintStatus());
                if (game.IsEmptySet)
                {
                    Console.WriteLine("Empty array reached!");
                    Console.ReadLine();
                    break;
                }
            }

            //int[,] testArray1 = new int[5, 5]
            //    { { 0, 1, 0, 0, 0 },

            //    { 1, 0, 0, 1, 1 },

            //    { 1, 1, 0, 0, 1 },

            //    { 0, 1, 0, 0, 0 },

            //    { 1, 0, 0, 0, 1 } };
            //game.SetValues(testArray1);
            //Console.WriteLine(game.PrintStatus());
            //game.StepForward();
            //Console.WriteLine(game.PrintStatus());
            //Console.ReadLine();
        }
    }
}
