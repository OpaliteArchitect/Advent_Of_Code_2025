namespace Advent_Of_Code_2025.Day6
{
    internal partial class Day6Puzzles
    {
        private const int OPERAND_LINES = 4;
        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static long SolvePuzzle1(string[] inputs)
        {
            List<int[]> operands = inputs.Take(OPERAND_LINES)
                .Select(line =>
                {
                    int[] num = line
                        .Split(' ')
                        .Where(num => !string.IsNullOrWhiteSpace(num))
                        .Select(int.Parse)
                        .ToArray();
                    return num;
                })
                .ToList();

            char[] operators = inputs[OPERAND_LINES]
                .Split(' ')
                .Where(sign => !string.IsNullOrWhiteSpace(sign))
                .Select(char.Parse)
                .ToArray();

            long answer = 0;

            for (int i = 0; i < operands[0].Length; i++)
            {
                long columnAnswer = operators[i] switch
                {
                    '+' => operands.Select(num => (long)num[i]).Sum(),
                    '*' => operands.Select(num => (long)num[i]).Aggregate((product, multiplier) => product * multiplier),
                    _ => throw new InvalidOperationException("Plus and times only")
                };

                answer += columnAnswer;
            }

            return answer;
        }
    }
}