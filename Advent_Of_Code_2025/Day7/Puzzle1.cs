namespace Advent_Of_Code_2025.Day7
{
    internal partial class Day7Puzzles
    {
        private const char START = 'S';
        private const char SPLITTER = '^';

        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static int SolvePuzzle1(string[] inputs)
        {
            int answer = 0;

            int rows = inputs.Length;
            int columns = inputs[0].Length;

            HashSet<int> columnsWithBeam = [];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var cell = inputs[i][j];
                    switch (cell)
                    {
                        case START:
                            columnsWithBeam.Add(j);
                            break;
                        case SPLITTER:
                            if (columnsWithBeam.Remove(j))
                            {
                                answer++;
                                columnsWithBeam.Add(j - 1);
                                columnsWithBeam.Add(j + 1);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            return answer;
        }
    }
}