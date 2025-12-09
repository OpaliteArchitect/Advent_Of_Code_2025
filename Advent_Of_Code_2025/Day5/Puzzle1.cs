namespace Advent_Of_Code_2025.Day5
{
    internal partial class Day5Puzzles
    {
        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        private static List<Ranges> IntervalMerge(string[] rangesRaw)
        {
            Ranges[] rangesUnsorted = rangesRaw
                .Select(line =>
                {
                    long[] parts = line.Split('-')
                        .Select(long.Parse)
                        .ToArray();
                    return new Ranges(parts[0], parts[1]);
                })
                .ToArray();

            Ranges[] rangesSorted = rangesUnsorted
                .OrderBy(r => r.Start)
                .ThenBy(r => r.End)
                .ToArray();

            List<Ranges> rangesMerged = new([rangesSorted[0]]);
            for (int i = 1; i < rangesSorted.Length; i++)
            {
                int lastIndex = rangesMerged.Count - 1;
                if (rangesSorted[i].Start <= rangesMerged[lastIndex].End)
                {
                    rangesMerged[lastIndex].End = Math.Max(rangesSorted[i].End, rangesMerged[lastIndex].End);
                }
                else
                {
                    rangesMerged.Add(rangesSorted[i]);
                }
            }

            return rangesMerged;
        }

        public static int SolvePuzzle1(string[] input)
        {
            int space = Array.IndexOf(input, string.Empty);

            string[] rangesRaw = input.Take(space).ToArray();
            List<Ranges> ranges = IntervalMerge(rangesRaw);

            long[] ids = input.Skip(space + 1)
                .Select(long.Parse)
                .ToArray();

            int answer = 0;

            foreach (var id in ids)
            {
                if (InRange(0, ranges.Count - 1, id))
                {
                    answer++;
                }
            }

            bool InRange(int start, int end, long id)
            {
                if (start > end)
                {
                    return false;
                }

                int midpoint = (start + end) / 2;

                if (id >= ranges[midpoint].Start && id <= ranges[midpoint].End)
                {
                    return true;
                }

                if (id < ranges[midpoint].Start)
                {
                    return InRange(start, midpoint - 1, id);
                }
                else
                {
                    return InRange(midpoint + 1, end, id);
                }
            }

            return answer;
        }
    }
}