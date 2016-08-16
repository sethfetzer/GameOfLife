using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Server
{
    public class Game
    {
        #region Properties
        public bool[,] GameArray { get; private set; }
        public bool IsEmptySet
        {
            get
            {
                foreach (bool cell in GameArray)
                {
                    if (cell)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        #endregion
        #region ctor
        public Game()
        {
            GameArray = new bool[5,5];
            Randomize();
        }
        public Game(int xSize, int ySize)
        {
            GameArray = new bool[xSize, ySize];
            Randomize();            
        }
        public Game(int[,] array)
        {
            SetValues(array);
        }
        
        #endregion
        #region Public Methods
        public void StepForward()
        {
            //iterate through the 2-dimensional GameArray with a nested for loop.
            bool[,] tmpArray = new bool[GameArray.GetLength(0),GameArray.GetLength(1)];
            Array.Copy(GameArray, tmpArray, GameArray.Length);
            for(int x=0; x<GameArray.GetLength(0); x++)
                for(int y=0; y<GameArray.GetLength(1); y++)
                {
                    //the adjacent population will be used to determine whether the cell lives or dies 
                    int population = GetPopulation(x,y);
                    bool isAlive = GameArray[x, y];

                    // 1) Any live cell with fewer than two live neighbours dies (underpopulation)
                    // 2) Any live cell with two or three live neighbours lives on to
                    //    the next generation(survival)
                    //    DEVNOTE: The cell is already alive so don't change anything.
                    // 3) Any live cell with more than three live neighbours dies (overcrowding)
                    if (isAlive && (population < 2 || population > 3))
                        tmpArray[x, y] = false;
                    // 4) Any dead cell with exactly three live neighbours becomes a
                    // live cell (reproduction)
                    else if (!isAlive && population == 3)
                        tmpArray[x, y] = true;
                }
            GameArray = tmpArray;
        }
        public void SetValues(int[,] array)
        {
            GameArray = ConvertToBool(array);            
        }
        public void Randomize()
        {
            //all new bools initialize to false.
            //iterate through the 2-dimensional GameArray with a nested for loop and randomly set values.
            Random random = new Random();
            for (int x = 0; x < GameArray.GetLength(0); x++)
                for (int y = 0; y < GameArray.GetLength(1); y++)
                {
                    GameArray[x, y] = Convert.ToBoolean(random.Next(2));
                }
        }
        public int[,] ConvertToInt(bool[,] boolArray)
        {
            int[,] intArray = new int[boolArray.GetLength(0), boolArray.GetLength(1)];
            //iterate through the int array and convert to boolean.
            for (int x = 0; x < boolArray.GetLength(0); x++)
                for (int y = 0; y < boolArray.GetLength(1); y++)
                {
                    intArray[x, y] = Convert.ToInt16(boolArray[x, y]);
                }
            return intArray;
        }
        public bool[,] ConvertToBool(int[,] intArray)
        {
            bool[,] boolArray = new bool[intArray.GetLength(0), intArray.GetLength(1)];
            //iterate through the int array and convert to boolean.
            for (int x = 0; x < intArray.GetLength(0); x++)
                for (int y = 0; y < intArray.GetLength(1); y++)
                {
                    boolArray[x, y] = Convert.ToBoolean(intArray[x, y]);
                }
            return boolArray;
        }
        public string PrintStatus()
        {
            int[,] intArray = ConvertToInt(GameArray);
            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < GameArray.GetLength(0); x++)
            {
                for (int y = 0; y < GameArray.GetLength(1); y++)
                {
                    sb.AppendFormat("{0} ", intArray[x, y].ToString());
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
        
        #endregion
        #region Private Methods
        private int GetPopulation(int xLoc, int yLoc)
        {
            int population = 0;
            
            for (int x = xLoc - 1; x <= xLoc + 1; x++)
            {
                for (int y = yLoc - 1; y <= yLoc + 1; y++)
                {
                    //skip any negative x or y coordinates, coordinates past the size of the array, or the current location
                    if (x < 0 || x >= GameArray.GetLength(0) ||
                        y < 0 || y >= GameArray.GetLength(1) ||
                        (x == xLoc && y == yLoc))
                    {
                        continue;
                    }
                    if (GameArray[x, y])
                    {
                        population++;
                    }
                }
            }
            return population;
        }
        #endregion
    }
}
