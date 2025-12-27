using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.CompilerServices;
using _8_Tails_solver;

//note : i write the original code then i did optimize it using AI tools 
namespace Tails_solver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] goal = { { '1', '2', '3' },
                             { '4', '5', '6' },
                             { '7', '8', ' ' }
            };
            Console.Write("Please enter the path to your text file (e.g., input.txt): ");
            string filePath = Console.ReadLine();
            try
            {
                char[,] start = Reader.ReadFileTo2DCharArray(filePath);
                Console.WriteLine("Starting Puzzle State:");
                Node tempStartNode = new Node(start, null, null);
                tempStartNode.PrintState();
                Console.WriteLine("\nGoal State:");
                Node tempGoalNode = new Node(goal, null, null);
                tempGoalNode.PrintState();
                Console.WriteLine("\nSolving...");
                Solution solver = new Solution();
                List<string> solutionPath = solver.Solve(start, goal);
                if (solutionPath != null)
                {
                    Console.WriteLine("\nSolution Found!\nPath:");
                    foreach (string action in solutionPath)
                    {
                        Console.WriteLine($"- {action}");
                    }
                    Console.WriteLine($"Total moves: {solutionPath.Count}");
                }
                else
                {
                    Console.WriteLine("\nNo solution found for this starting state.");
                }
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"\nError: The file '{filePath}' was not found.");
                Console.WriteLine("Please ensure the file exists and the path is correct.");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"\nData Error: {ex.Message}");
                Console.WriteLine("Consider using a 'char[][]' (jagged array) if your lines have varying lengths.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
            }
        }
    }
}
