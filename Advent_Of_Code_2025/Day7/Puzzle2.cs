namespace Advent_Of_Code_2025.Day7
{
    internal partial class Day7Puzzles
    {
        public static long SolvePuzzle2(string[] inputs)
        {
            int rows = inputs.Length;
            int columns = inputs[0].Length;

            long[] timelinesPerColumn = new long[columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var cell = inputs[i][j];
                    switch (cell)
                    {
                        case START:
                            timelinesPerColumn[j] = 1;
                            break;
                        case SPLITTER:
                            if (timelinesPerColumn[j] > 0)
                            {
                                timelinesPerColumn[j - 1] += timelinesPerColumn[j];
                                timelinesPerColumn[j + 1] += timelinesPerColumn[j];
                                timelinesPerColumn[j] = 0;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return timelinesPerColumn.Sum();
        }
    }
}