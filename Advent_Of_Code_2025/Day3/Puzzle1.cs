namespace Advent_Of_Code_2025.Day3
{
    internal partial class Day3Puzzles
    {
        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static int SolvePuzzle1(string[] banks)
        {
            int answer = 0;
            foreach (var bank in banks)
            {
                char tensDigit = '0';
                char onesDigit = '0';

                for (int i = 0; i < bank.Length; i++)
                {
                    if (i < bank.Length - 1 && bank[i] > tensDigit)
                    {
                        tensDigit = bank[i];
                        onesDigit = '0';
                    }
                    else if (bank[i] > onesDigit)
                    {
                        onesDigit = bank[i];
                    }
                }

                answer += (tensDigit - '0') * 10 + (onesDigit - '0');
            }

            return answer;
        }
    }
}