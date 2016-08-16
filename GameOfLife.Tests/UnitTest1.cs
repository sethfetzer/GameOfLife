using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.Server;

namespace GameOfLife.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SuppliedTestMethod()
        {
            Game game = new Game();
            int[,] testArray1 = new int[5, 5] 
                { { 0, 1, 0, 0, 0 },
                  { 1, 0, 0, 1, 1 },
                  { 1, 1, 0, 0, 1 },
                  { 0, 1, 0, 0, 0 },
                  { 1, 0, 0, 0, 1 } };

            int[,] expectedOutput1 = new int[5, 5]
                { { 0, 0, 0, 0, 0 },
                  { 1, 0, 1, 1, 1 },
                  { 1, 1, 1, 1, 1 },
                  { 0, 1, 0, 0, 0 },
                  { 0, 0, 0, 0, 0 } };

            game.SetValues(testArray1);
            game.StepForward();
            int[,] testOutput1 = game.ConvertToInt(game.GameArray);            
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                {
                    Assert.AreEqual(testOutput1[x,y], expectedOutput1[x,y]);
                }
        }
        //One of the pattern types on Wikipiedia is an oscillator called a blinker. 
        //It is 3 lines that flips horizontally and vertically.
        [TestMethod]
        public void BlinkerTestMethod()
        {
            Game game = new Game();
            int[,] testArray1 = new int[5, 5]
                { { 0, 1, 0, 0, 0 },
                  { 0, 1, 0, 0, 0 },
                  { 0, 1, 0, 0, 0 },
                  { 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0 } };

            int[,] expectedOutput1 = new int[5, 5]
                { { 0, 0, 0, 0, 0 },
                  { 1, 1, 1, 0, 0 },
                  { 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0 } };

            game.SetValues(testArray1);
            game.StepForward();
            int[,] testOutput1 = game.ConvertToInt(game.GameArray);
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                {
                    Assert.AreEqual(testOutput1[x, y], expectedOutput1[x, y]);
                }
            game.StepForward();
            int[,] testOutput2 = game.ConvertToInt(game.GameArray);
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                {
                    Assert.AreEqual(testOutput2[x, y], testArray1[x, y]);
                }
        }

        //One of the pattern types on Wikipiedia is a Still life called a beehive. 
        //It does not move from step to step.
        [TestMethod]
        public void BeehiveTestMethod()
        {
            Game game = new Game();
            int[,] testArray1 = new int[5, 5]
                { { 0, 0, 0, 0, 0 },
                  { 0, 0, 1, 1, 0 },
                  { 0, 1, 0, 0, 1 },
                  { 0, 0, 1, 1, 0 },
                  { 0, 0, 0, 0, 0 } };

            

            game.SetValues(testArray1);
            game.StepForward();
            int[,] testOutput1 = game.ConvertToInt(game.GameArray);
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                {
                    Assert.AreEqual(testOutput1[x, y], testArray1[x, y]);
                }
            game.StepForward();
            int[,] testOutput2 = game.ConvertToInt(game.GameArray);
            for (int x = 0; x < 5; x++)
                for (int y = 0; y < 5; y++)
                {
                    Assert.AreEqual(testOutput2[x, y], testArray1[x, y]);
                }
        }

    }
}
