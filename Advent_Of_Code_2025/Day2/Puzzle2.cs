using System.Text;

namespace Advent_Of_Code_2025.Day2
{
    internal partial class Day2Puzzles
    {
        public static Int128 SolvePuzzle2(string[] ranges)
        {
            static bool IsRepeating(string num)
            {
                for (int i = 1; i <= num.Length / 2; i++)
                {
                    if (num.Length % i is not 0)
                    {
                        continue;
                    }

                    int repeat = num.Length / i;
                    string pattern = num.Substring(0, i);

                    StringBuilder expected = new();
                    for (int j = 0; j < repeat; j++)
                    {
                        expected.Append(pattern);
                    }

                    if (num.Equals(expected.ToString()))
                    {
                        return true;
                    }
                }

                return false;
            }

            Int128 answer = 0;

            foreach (var range in ranges)
            {
                var limit = range.Split("-");
                var start = long.Parse(limit[0]);
                var end = long.Parse(limit[1]);

                for (long i = start; i <= end; i++)
                {
                    var num = i.ToString();

                    if (IsRepeating(num))
                    {
                        answer += Int128.Parse(num);
                    }
                }
            }

            return answer;
        }
    }
}