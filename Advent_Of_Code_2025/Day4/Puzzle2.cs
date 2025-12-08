namespace Advent_Of_Code_2025.Day4
{
    internal partial class Day4Puzzles
    {
        public static int SolvePuzzle2(string[] input)
        {
            int rows = input.Length;
            int columns = input[0].Length;

            bool[,] rollsOfPaper = new bool[rows, columns];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (input[r][c] is '@')
                    {
                        rollsOfPaper[r, c] = true;
                    }
                }
            }

            int answer = 0;

            bool clearedPaper;
            do
            {
                int[,] grid = new int[rows, columns];
                clearedPaper = false;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (rollsOfPaper[r, c] is false)
                        {
                            continue;
                        }

                        foreach (var cell in directions)
                        {
                            int targetRow = r + cell.rowOffset;
                            int targetColumn = c + cell.columnOffset;
                            if (InBounds(targetRow, targetColumn))
                            {
                                grid[targetRow, targetColumn] += 1;
                            }
                        }
                    }
                }

                bool InBounds(int r, int c)
                {
                    return r >= 0 && r < rows && c >= 0 && c < columns;
                }

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (grid[r, c] < 4 && rollsOfPaper[r, c] is true)
                        {
                            clearedPaper = true;
                            rollsOfPaper[r, c] = false;
                            answer++;
                        }
                    }
                }

            } while (clearedPaper);

            return answer;
        }
    }
}