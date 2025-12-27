using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Tails_solver
{
    public partial class Node
    {
        private static readonly Dictionary<char, (int row, int col)> goal_positions = new Dictionary<char, (int row, int col)>
        {
            { '1', (0, 0) }, { '2', (0, 1) }, { '3', (0, 2) },
            { '4', (1, 0) }, { '5', (1, 1) }, { '6', (1, 2) },
            { '7', (2, 0) }, { '8', (2, 1) }, { ' ', (2, 2) }
        };
        public char[,] State { get; }
        public Node Parent { get; }
        public string Action { get; }
        public int GCost { get; }
        public int HCost { get; }
        public int FCost { get; }
        public Node(char[,] state, Node parent, string action)
        {
            this.State = CopyState(state);
            this.Parent = parent;
            this.Action = action;
            if (parent == null)
            {
                this.GCost = 0;
            }
            else
            {
                this.GCost = parent.GCost + 1;
            }
            this.HCost = CalculateManhattanDistance();
            this.FCost = GCost + HCost;
        }
        private char[,] CopyState(char[,] original)
        {
            if (original == null) return null;
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            char[,] copy = new char[rows, cols];
            Array.Copy(original, copy, original.Length);
            return copy;
        }
        public int CalculateManhattanDistance()
        {
            int totalDistance = 0;
            int numRows = State.GetLength(0);
            int numCols = State.GetLength(1);
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    char tile = State[i, j];
                    if (goal_positions.TryGetValue(tile, out (int goalRow, int goalCol) goalPos))
                    {
                        int distance = Math.Abs(i - goalPos.goalRow) + Math.Abs(j - goalPos.goalCol);
                        totalDistance += distance;
                    }
                }
            }
            return totalDistance;
        }
        public string GetStateKey()
        {
            if (State == null) return null;

            return GetStateKeyFromMatrix(State);
        }
        public static bool AreStatesEqual(char[,] arr1, char[,] arr2)
        {
            if (arr1 == null || arr2 == null) return arr1 == arr2;
            if (arr1.GetLength(0) != arr2.GetLength(0) || arr1.GetLength(1) != arr2.GetLength(1)) return false;
            int rows = arr1.GetLength(0);
            int cols = arr1.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (arr1[i, j] != arr2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string GetStateKeyFromMatrix(char[,] matrix)
        {
            if (matrix == null) return null;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j]);
                }
            }
            return sb.ToString();
        }
        public void PrintState()
        {
            if (State == null)
            {
                Console.WriteLine("State is null.");
                return;
            }

            int rows = State.GetLength(0);
            int cols = State.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(State[i, j]); Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
