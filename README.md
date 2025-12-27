# 8_tailes_solver
This project is a C# console application that solves the classic 8-puzzle problem (also known as the sliding puzzle).
The program reads an initial puzzle state from a text file, attempts to solve it, and outputs the sequence of moves required to reach the goal state.
## Overview<br>
The 8-puzzle consists of a 3×3 grid with tiles numbered 1 through 8 and one empty space.<br>
The objective is to rearrange the tiles to match the goal state:<br>
1 2 3<br>
4 5 6<br>
7 8  <br>
This solver:<br>
- Reads the starting state from a text file<br>
- Prints both the starting and goal states<br>
- Uses a search algorithm to find the solution path.<br>
- Displays the sequence of moves and the total number of steps required.<br>
## Features<br>
- File Input: Load puzzle states from a text file.<br>
- Validation: Handles invalid or missing files gracefully.<br>
- Puzzle Solver: Finds the shortest path to the goal state (if solvable).<br>
- User-Friendly Output: Prints the puzzle states and solution steps clearly.<br>
## Project Structure<br>
- Program.cs → Entry point of the application.<br>
- Reader.cs → Utility for reading puzzle states from text files.<br>
- Node.cs → Represents puzzle states and transitions.<br>
- Solution.cs → Contains the solving algorithm.<br>
### Example Input File (input.txt)<br>
1 2 3<br>
4 5 6<br>
7   8<br>
### Example Output<br>
Starting Puzzle State:<br>
1 2 3<br>
4 5 6<br>
7   8<br>
<br>
Goal State:<br>
1 2 3<br>
4 5 6<br>
7 8  <br>
<br>
Solving...<br>
<br>
Solution Found!<br>
Path:<br>
- Move empty space left<br>
- Move empty space down<br>
Total moves: 2<br>

