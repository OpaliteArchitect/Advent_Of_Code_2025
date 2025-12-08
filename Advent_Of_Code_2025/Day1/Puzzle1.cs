namespace Advent_Of_Code_2025.Day1
{
    internal partial class Day1Puzzles
    {
        private const int DIAL_START = 50;
        private const int DIAL_SIZE = 100;

        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static int SolvePuzzle1(string[] rotations)
        {
            int dialPosition = DIAL_START;
            int answer = 0;

            foreach (var rotation in rotations)
            {
                if (string.IsNullOrEmpty(rotation))
                {
                    continue;
                }

                char direction = rotation[0];
                int timesRotated = Int32.Parse(rotation.Substring(1));

                switch (direction)
                {
                    case 'R':
                        dialPosition = (dialPosition + timesRotated) % DIAL_SIZE;
                        break;
                    case 'L':
                        int effectiveRotation = timesRotated % DIAL_SIZE;
                        dialPosition = (dialPosition - effectiveRotation + DIAL_SIZE) % DIAL_SIZE;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid direction");
                }

                if (dialPosition is 0)
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
