namespace Advent_Of_Code_2025.Day4
{
    internal partial class Day4Puzzles
    {
        private static readonly (int rowOffset, int columnOffset)[] directions =
        [
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1),           (0, 1),
            (1, -1),  (1, 0),  (1, 1)
        ];

        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static int SolvePuzzle1(string[] input)
        {
            int rows = input.Length;
            int columns = input[0].Length;

            int[,] grid = new int[rows, columns];

            int answer = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (input[r][c] is '.')
                    {
                        continue;
                    }

                    foreach (var (rowOffset, columnOffset) in directions)
                    {
                        int targetRow = r + rowOffset;
                        int targetColumn = c + columnOffset;
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
                    if (grid[r, c] < 4 && input[r][c] is '@')
                    {
                        answer++;
                    }
                }
            }

            return answer;
        }
    }
}