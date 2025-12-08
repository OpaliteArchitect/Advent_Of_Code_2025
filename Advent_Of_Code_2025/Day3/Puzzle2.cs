using System.Numerics;

namespace Advent_Of_Code_2025.Day3
{
    internal partial class Day3Puzzles
    {
        public static BigInteger SolvePuzzle2(string[] banks)
        {
            const int JOLTAGE_BATTERIES = 12;

            BigInteger answer = 0;

            foreach (var bank in banks)
            {
                (int index, char value)[] digits = new (int, char)[JOLTAGE_BATTERIES];
                Array.Fill(digits, (-1, '/'));

                for (int digit = 0; digit < JOLTAGE_BATTERIES; digit++)
                {
                    int start = digit is 0 ? 0 : digits[digit - 1].index + 1;
                    int end = bank.Length - JOLTAGE_BATTERIES + digit;

                    for (int i = start; i <= end; i++)
                    {
                        if (bank[i] > digits[digit].value)
                        {
                            digits[digit] = (i, bank[i]);
                            if (bank[i] is '9')
                            {
                                break;
                            }
                        }
                    }
                }

                BigInteger bankResult = 0;
                foreach ((_, char value) in digits)
                {
                    bankResult = bankResult * 10 + (value - '0');
                }

                answer += bankResult;
            }

            return answer;
        }
    }
}