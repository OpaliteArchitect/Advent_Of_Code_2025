namespace Advent_Of_Code_2025.Day5
{
    internal partial class Day5Puzzles
    {
        public static long SolvePuzzle2(string[] input)
        {
            int space = Array.IndexOf(input, string.Empty);

            string[] rangesRaw = input.Take(space).ToArray();
            List<Ranges> ranges = IntervalMerge(rangesRaw);

            long answer = 0;

            foreach (var range in ranges)
            {
                answer += range.End - range.Start + 1;
            }

            return answer;
        }
    }
}