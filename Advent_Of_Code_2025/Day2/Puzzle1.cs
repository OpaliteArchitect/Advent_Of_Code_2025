namespace Advent_Of_Code_2025.Day2
{
    internal partial class Day2Puzzles
    {
        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            var text = await File.ReadAllTextAsync(path);

            return text.Split(",");
        }

        public static long SolvePuzzle1(string[] ranges)
        {
            long answer = 0;

            foreach (var range in ranges)
            {
                if (string.IsNullOrEmpty(range))
                {
                    continue;
                }

                var limit = range.Split("-");
                var start = long.Parse(limit[0]);
                var end = long.Parse(limit[1]);

                for (long i = start; i <= end; i++)
                {
                    var num = i.ToString();
                    if (num.Substring(0, num.Length / 2) == num.Substring(num.Length / 2))
                    {
                        answer += i;
                    }
                }
            }

            return answer;
        }
    }
}
