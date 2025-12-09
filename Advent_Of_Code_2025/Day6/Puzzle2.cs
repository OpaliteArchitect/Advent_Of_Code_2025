using System.Text;

namespace Advent_Of_Code_2025.Day6
{
    internal partial class Day6Puzzles
    {
        public static long SolvePuzzle2(string[] inputs)
        {
            string[] operandsMap = inputs.Take(OPERAND_LINES).ToArray();

            char[] operators = inputs[OPERAND_LINES]
                .Split(' ')
                .Where(op => !string.IsNullOrWhiteSpace(op))
                .Select(char.Parse)
                .ToArray();

            long answer = 0;

            int group = 0;
            List<long> operands = [];
            StringBuilder operandRaw;
            long groupAnswer;
            for (int i = 0; i < operandsMap[0].Length; i++)
            {
                operandRaw = new();
                for (int j = 0; j < OPERAND_LINES; j++)
                {
                    char digit = operandsMap[j][i];
                    if (char.IsNumber(digit))
                    {
                        operandRaw.Append(digit);
                    }
                }

                if (operandRaw.Length is not 0)
                {
                    operands.Add(long.Parse(operandRaw.ToString()));
                }
                else
                {
                    groupAnswer = operators[group] switch
                    {
                        '+' => operands.Aggregate((total, addend) => total + addend),
                        '*' => operands.Aggregate((product, multiplier) => product * multiplier),
                        _ => throw new InvalidOperationException("Plus and times only")
                    };

                    answer += groupAnswer;

                    group++;
                    operands.Clear();
                }
            }

            groupAnswer = operators[group] switch
            {
                '+' => operands.Aggregate((total, addend) => total + addend),
                '*' => operands.Aggregate((product, multiplier) => product * multiplier),
                _ => throw new InvalidOperationException("Plus and times only")
            };

            answer += groupAnswer;

            return answer;
        }
    }
}