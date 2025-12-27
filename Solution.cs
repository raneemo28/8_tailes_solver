using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Tails_solver
{
    public class Solution
    {
        public List<string> Solve(char[,] puzzle, char[,] goal)
        {
            if (puzzle == null || goal == null)
            {
                Console.WriteLine("Input puzzle or goal state is null.");
                return null;
            }
            if (puzzle.Rank != 2 || goal.Rank != 2 || puzzle.GetLength(0) != goal.GetLength(0) || puzzle.GetLength(1) != goal.GetLength(1))
            {
                Console.WriteLine("Input states must be 2D arrays of the same dimensions.");
                return null;
            }
            Node startNode = new Node(puzzle, null, null);
            PQueueFrontier frontier = new PQueueFrontier();
            frontier.Add(startNode);
            HashSet<string> exploredStates = new HashSet<string>();
            int[] dr = { -1, 1, 0, 0 }; // Delta Row: Up, Down, Left, Right 
            int[] dc = { 0, 0, -1, 1 }; // Delta Column: Up, Down, Left, Right 
            string[] actions = { "Up", "Down", "Left", "Right" };
            int rows = puzzle.GetLength(0);
            int cols = puzzle.GetLength(1);
            while (!frontier.Empty())
            {
                Node currentNode = frontier.Remove();
                if (Node.AreStatesEqual(currentNode.State, goal))
                {
                    List<string> path = new List<string>();
                    Node node = currentNode;
                    while (node.Parent != null)
                    {
                        path.Add(node.Action);
                        node = node.Parent;
                    }
                    path.Reverse();
                    return path;
                }
                string currentStateKey = currentNode.GetStateKey();
                exploredStates.Add(currentStateKey);
                int blankRow = -1, blankCol = -1;
                bool blankFound = false;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (currentNode.State[i, j] == ' ')
                        {
                            blankRow = i;
                            blankCol = j;
                            blankFound = true;
                            break;
                        }
                    }
                    if (blankFound) break;
                }
                if (!blankFound) continue;
                for (int k = 0; k < 4; k++)
                {
                    int newRow = blankRow + dr[k];
                    int newCol = blankCol + dc[k];
                    string action = actions[k];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        char[,] newState = SwapTiles(currentNode.State, blankRow, blankCol, newRow, newCol);
                        Node newNode = new Node(newState, currentNode, action);
                        string newNodeKey = newNode.GetStateKey();
                        if (!exploredStates.Contains(newNodeKey))
                        {
                            frontier.Add(newNode);
                        }
                    }
                }
            }
            return null;
        }
        private static char[,] SwapTiles(char[,] state, int r1, int c1, int r2, int c2)
        {
            int rows = state.GetLength(0);
            int cols = state.GetLength(1);
            char[,] newState = new char[rows, cols];
            Array.Copy(state, newState, state.Length);
            char temp = newState[r1, c1];
            newState[r1, c1] = newState[r2, c2];
            newState[r2, c2] = temp;

            return newState;
        }
    }
}
