using System;
using System.Text;

namespace SpiralNumbers
{
    internal class Program
    {
        private const int InvalidArrayValue = -1;

        private static void Main(string[] args)
        {
            //PrintSpiralNumbers(1, 1);

            //PrintSpiralNumbers(2, 2);

            //PrintSpiralNumbers(5, 5);

            //PrintSpiralNumbers(5, 7);

            PrintSpiralNumbers(40, 50);
        }

        private static void PrintSpiralNumbers(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("width must be greater than 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException("width must be greater than 0");
            }

            int currentNumber = width * height;
            int maxDisplayChars = currentNumber.ToString().Length;

            int[][] printArray = new int[height][];

            // Initialize array with invalid values
            for (int i = 0; i < height; ++i)
            {
                printArray[i] = new int[width];

                for (int j = 0; j < width; ++j)
                {
                    printArray[i][j] = InvalidArrayValue;
                }
            }

            int heightIndex = 0;
            int widthIndex = width - 1;
            var direction = MoveDirection.Left;
            
            while (0 < currentNumber)
            {
                printArray[heightIndex][widthIndex] = currentNumber;

                switch (direction)
                {
                    case MoveDirection.Left:
                        if (CheckIndex(ref printArray, width, height, (widthIndex - 1), heightIndex) == true)
                        {
                            widthIndex--;
                        }
                        else
                        {
                            direction = MoveDirection.Down;
                            heightIndex++;
                        }
                        break;
                    case MoveDirection.Down:
                        if (CheckIndex(ref printArray, width, height, widthIndex, (heightIndex + 1)) == true)
                        {
                            heightIndex++;
                        }
                        else
                        {
                            direction = MoveDirection.Right;
                            widthIndex++;
                        }
                        break;
                    case MoveDirection.Right:
                        if (CheckIndex(ref printArray, width, height, (widthIndex + 1), heightIndex) == true)
                        {
                            widthIndex++;
                        }
                        else
                        {
                            direction = MoveDirection.Up;
                            heightIndex--;
                        }
                        break;
                    case MoveDirection.Up:
                        if (CheckIndex(ref printArray, width, height, widthIndex, (heightIndex - 1)) == true)
                        {
                            heightIndex--;
                        }
                        else
                        {
                            direction = MoveDirection.Left;
                            widthIndex--;
                        }
                        break;
                    default:
                        break;
                }

                currentNumber--;
            }

            foreach (var row in printArray)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var num in row)
                {
                    sb.AppendFormat("{0} ", num.ToString().PadLeft(maxDisplayChars, ' '));
                }

                Console.WriteLine(sb.ToString().Trim());
            }

            Console.WriteLine();
        }

        private static bool CheckIndex(ref int[][] array, int width, int height, int widthIndex, int heightIndex)
        {
            bool isOkay = true;

            if (!(0 <= widthIndex && widthIndex <= width - 1))
            {
                // Width index is not within array bounds
                isOkay = false;
            }

            if (!(0 <= heightIndex && heightIndex <= height - 1))
            {
                // Height index is not within array bounds
                isOkay = false;
            }

            if (isOkay == true && array[heightIndex][widthIndex] != InvalidArrayValue)
            {
                // Array value is not -1
                isOkay = false;
            }

            return isOkay;
        }

        private enum MoveDirection : int
        {
            Left = 1,
            Down = 2,
            Right = 3,
            Up = 4
        }
    }
}