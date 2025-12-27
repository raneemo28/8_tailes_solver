using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Tails_solver
{
    class Reader
    {
        public static char[,] ReadFileTo2DCharArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                Console.WriteLine("Warning: The file is empty. Returning an empty 2D array.");
                return new char[0, 0];
            }

            int numRows = lines.Length;
            int numCols = lines[0].Length;

            if (!lines.All(line => line.Length == numCols))
            {
                throw new InvalidDataException("Error: All lines in the file must have the same length to be stored in a rectangular 2D char array.");
            }
            char[,] charArray = new char[numRows, numCols];

            for (int r = 0; r < numRows; r++)
            {
                for (int c = 0; c < numCols; c++)
                {
                    charArray[r, c] = lines[r][c];
                }
            }

            return charArray;
        }
    }
}
